using Entities.DataTransferObjects.Home;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using Services.Contracts;
using System.Diagnostics;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITenderService _tenderService;
        private readonly ISupplierService _supplierService;

        public HomeController(SignInManager<User> signInManager, ITenderService tenderService, ISupplierService supplierService)
        {
            _signInManager = signInManager;
            _tenderService = tenderService;
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            HomeViewModel homeViewModel = new();
            if (user == null)
            {
                return View(homeViewModel);
            }
            homeViewModel.UserName = user.UserName;
            homeViewModel.RoleName = user.Role_Name;

            if (user.Role_Name == "Supplier")
            {
                homeViewModel.SupplierHomeGetTendersDTO = await _tenderService.GetSupplierHomeGetTendersDTO(user, 5, true);
            }
            else if (user.Role_Name == "Admin")
            {
                homeViewModel.AdminHomeGetTendersDTO = await _tenderService.GetAdminHomeTenders();
            }
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
