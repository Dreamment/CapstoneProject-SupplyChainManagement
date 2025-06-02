using Entities.DataTransferObjects.Create;
using Entities.DataTransferObjects.Filter;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using Services.Contracts;

namespace MVCApp.Controllers
{
    [Authorize(Roles = "Supplier,Admin")]
    public class TenderController : Controller
    {
        private readonly ITenderService _tenderService;
        private readonly ISupplierService _supplierService;
        private readonly IBidService _bidService;
        private readonly ITenderCategoryService _tenderCategoryService;
        private readonly SignInManager<User> _signInManager;

        public TenderController(
            ITenderService tenderService,
            ISupplierService supplierService,
            IBidService bidService,
            ITenderCategoryService tenderCategoryService,
            SignInManager<User> signInManager)
        {
            _tenderService = tenderService;
            _supplierService = supplierService;
            _bidService = bidService;
            _signInManager = signInManager;
            _tenderCategoryService = tenderCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string? keyword,
            List<int>? categoryIds,
            List<int>? bidStatuses,
            List<TenderStatus>? tenderStatuses,
            int page=1,
            TenderSortOrder tenderSortOrder = TenderSortOrder.Id,
            int pageSize = 15)
        {
            IEnumerable<int> acceptedPageSizes =
            [
                15, 30, 45
            ];

            if (!acceptedPageSizes.Contains(pageSize))
            {
                pageSize = 15;
            }

            var user = await _signInManager.UserManager.GetUserAsync(User);

            bool filterNotBidded = bidStatuses?.Contains(-1) == true;
            var bidStatusEnums = bidStatuses?
                .Where(x => x != -1)
                .Select(x => (BidStatus)x)
                .ToList() ?? [];

            TenderFilter filter = new(
                keyword ?? string.Empty,
                categoryIds ?? [],
                bidStatusEnums,
                tenderStatuses ?? []
            );

            var (tenders, supplierTenders,totalCount) = await _tenderService.GetUserTendersFilteredSortedPaged(user, filter, page, pageSize,tenderSortOrder, false);

            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var tenderCategories = await _tenderCategoryService.GetAllTenderCategoriesAsync(false);
            TenderIndexViewModel tenderIndexViewModel = new(tenders, supplierTenders, filter, tenderCategories, page, totalPages, tenderSortOrder, pageSize);
            ViewData["CustomContainerClass"] = "-fluid tender-index-container";
            return View(tenderIndexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Bid([FromQuery(Name = "tenderId")] int tenderId)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var supplier = await _supplierService.GetSupplier(user, false);
            var tender = await _tenderService.GetUserSpecificTender(supplier, tenderId, false);
            if (tender == null || tender.Status != TenderStatus.Open)
            {
                return RedirectToAction("AccessDenied", 
                    "Account", 
                    new { returnUrl = $"/tender/bid?tenderId={tenderId}" });
            }
            var currentBid = await _bidService.GetSpecificBidAsync(tenderId, supplier.SupplierName, false);
            var oldBids = await _bidService.GetOldBidsAsync(tenderId, supplier.SupplierName, false);
            return View((tender, currentBid, oldBids));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Bid([FromForm] CreateBidDTO createBidDTO)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var supplier = await _supplierService.GetSupplier(user, false);
            createBidDTO.SupplierName = supplier.SupplierName;
            var checkTender = await _tenderService.GetUserSpecificTender(supplier, createBidDTO.TenderId, false);
            if (checkTender == null || checkTender.Status != TenderStatus.Open)
            {
                return RedirectToAction("AccessDenied", 
                    "Account", 
                    new { returnUrl = $"/tender/bid?tenderId={createBidDTO.TenderId}" });
            }
            var result = await _bidService.MakeABidAsync(createBidDTO, false);
            if (result)
            {
                var tender = await _tenderService.GetTenderById(
                    createBidDTO.TenderId, false);
                return View("SuccessfullBid", (tender, createBidDTO));
            }
            else
            {
                ModelState.AddModelError("", "Failed to create bid.");
                var tender = await _tenderService.GetUserSpecificTender(supplier, createBidDTO.TenderId, false);
                return View(tender);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery(Name = "tenderId")] int tenderId)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var supplier = await _supplierService.GetSupplier(user, false);
            var tender = await _tenderService.GetUserSpecificTender(supplier, tenderId, false);
            if (tender == null)
            {
                return RedirectToAction("AccessDenied", 
                    "Account", 
                    new { returnUrl = $"/tender/details?tenderId={tenderId}" });
            }
            if (tender.Bids.Count > 0) 
            {
                foreach (var bid in tender.Bids)
                {
                    if (bid.SupplierName != supplier.SupplierName)
                        continue;
                    return View(new TenderDetailsViewModel(tender, bid));
                }
                return View(new TenderDetailsViewModel(tender, null));
            }
            return View(new TenderDetailsViewModel(tender, null));
        }
    }
}
