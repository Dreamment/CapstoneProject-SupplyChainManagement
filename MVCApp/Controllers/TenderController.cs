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
        private readonly SignInManager<User> _signInManager;

        public TenderController(
            ITenderService tenderService, 
            SignInManager<User> signInManager)
        {
            _tenderService = tenderService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var tenders = await _tenderService.GetUserTenders(user, false);
            return View(tenders);
        }
    }
}
