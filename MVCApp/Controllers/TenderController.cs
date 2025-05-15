using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class TenderController : Controller
    {
        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        public async Task<IActionResult> Index()
        {
            var tenders = await _tenderService.GetAllTenders(false);
            return View(tenders);
        }
    }
}
