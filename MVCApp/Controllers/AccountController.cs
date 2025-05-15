using Entities.AuthModels;
using Entities.DataTransferObjects.Auth;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAuthService _authenticationService;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IAuthService authenticationService, SignInManager<User> signInManager)
        {
            _authenticationService = authenticationService;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginUserDTO userDTO)
        {
            await _signInManager.SignOutAsync();
            LoginResult loginResult = new();
            if (ModelState.IsValid)
            {
                loginResult = await _authenticationService.LoginAsync(userDTO, false);
            }
            else
            {
                ModelState.AddModelError("", "Invalid data.");
                return View("LoginUnsuccessfull", (loginResult,userDTO));
            }

            if (loginResult.LoginStatus == LoginStatus.Success)
            {
                var signInManagerResult = await _signInManager.PasswordSignInAsync(userDTO.UserName, userDTO.Password, false, false);
                return View("LoginSuccessfull", userDTO);
            }
            else
            {
                ModelState.AddModelError("", loginResult.Message);
                return View("LoginUnsuccessfull", (loginResult, userDTO));
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterUserDTO userDTO)
        {
            RegisterResult result = new();
            if (ModelState.IsValid)
            {
                result = await _authenticationService.RegisterAsync(userDTO, false);
            }
            else
            {
                ModelState.AddModelError("", "Invalid data.");
                return View("RegisterUnsuccessfull", (result,userDTO));
            }

            if (result.RegisterStatus == RegisterStatus.Success)
            {
                return View("RegisterSuccessfull", userDTO);
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return View("RegisterUnsuccessfull", (result, userDTO));
            }
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
