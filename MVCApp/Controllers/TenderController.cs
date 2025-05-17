using Entities.DataTransferObjects.Create;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    [Authorize]
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
            var tenders = await _tenderService.GetUserTenders(user, false);
            var supplier = await _supplierService.GetSupplier(user, false);
            List<bool> isBidded = [.. Enumerable.Repeat(false, tenders.Count())];

            var index = 0;
            foreach (var tender in tenders)
            {
                var bidIndex = 0;
                foreach (var bid in tender.Bids)
                {
                    if (bid.Supplier_Name == supplier.Supplier_Name)
                    {
                        isBidded[index] = true;
                        break;
                    }
                    bidIndex++;
                    if (bidIndex == tender.Bids.Count)
                    {
                        isBidded[index] = false;
                        break;
                    }
                }
                index++;
            }
            return View((tenders, isBidded));
        }


        public async Task<IActionResult> Create([FromQuery(Name = "tenderId")] int tenderId)
        {
            var tender = await _tenderService.GetTenderById(
                tenderId, false);
            return View(tender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateBidDTO createBidDTO)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var supplier = await _supplierService.GetSupplier(user, false);
            createBidDTO.SupplierName = supplier.Supplier_Name;
            var result = await _bidService.CreateBidAsync(createBidDTO, false);
            if (result)
            {
                var tender = await _tenderService.GetTenderById(
                    createBidDTO.TenderId, false);
                return View("SuccessfullCreate", (tender, createBidDTO));
            }
            else
            {
                ModelState.AddModelError("", "Failed to create bid.");
                var tender = await _tenderService.GetTenderById(
                    createBidDTO.TenderId, false);
                return View(tender);
            }
        }
    }
}
