using Entities.DataTransferObjects.Create;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MVCApp.Controllers
{
    [Authorize(Roles = "Supplier")]
    public class TenderController : Controller
    {
        private readonly ITenderService _tenderService;
        private readonly ISupplierService _supplierService;
        private readonly IBidService _bidService;
        private readonly SignInManager<User> _signInManager;

        public TenderController(
            ITenderService tenderService,
            ISupplierService supplierService,
            IBidService bidService,
            SignInManager<User> signInManager)
        {
            _tenderService = tenderService;
            _supplierService = supplierService;
            _bidService = bidService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var (tenders, supplierTenders) = await _tenderService.GetUserTenders(user, false);
            return View((tenders, supplierTenders));
        }


        public async Task<IActionResult> Bid([FromQuery(Name = "tenderId")] int tenderId)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var supplier = await _supplierService.GetSupplier(user, false);
            var tender = await _tenderService.GetUserSpecificTender(supplier, tenderId, false);
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

        public async Task<IActionResult> Details([FromQuery(Name = "tenderId")] int tenderId)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var supplier = await _supplierService.GetSupplier(user, false);
            var tender = await _tenderService.GetUserSpecificTender(supplier, tenderId, false);
            if (tender == null)
            {
                return RedirectToAction("AccessDenied", 
                    "Account", 
                    new { returnUrl = $"/tender/details/{tenderId}" });
            }
            if (tender.Bids.Count > 0) 
            {
                bool isBidded = false;
                foreach (var bid in tender.Bids)
                    if (bid.SupplierName == supplier.SupplierName)
                        isBidded = true;
                return View((tender, isBidded));
            }
            return View((tender,false));
        }
    }
}
