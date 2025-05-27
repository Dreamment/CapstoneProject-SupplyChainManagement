using Entities.AuthModels;
using Entities.DataTransferObjects.Auth;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using Services.Contracts;
using System.Text.Json;

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

        [HttpGet]
        public IActionResult Login([FromQuery] string ReturnURL = "/")
        {
            bool isloggedIn = User.Identity.IsAuthenticated;
            if (isloggedIn)
                // redirect to the return URL if the user is already logged in
                return Redirect(ReturnURL);
            return View((ReturnURL, new LoginUserDTO()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginUserDTO userDTO, [FromQuery]string returnUrl)
        {
            await _signInManager.SignOutAsync();
            if (ModelState.IsValid)
            {
                var loginResult = await _authenticationService.LoginAsync(userDTO, false);
                if (loginResult.LoginStatus == LoginStatus.Success)
                {
                    var signInManagerResult = await _signInManager.PasswordSignInAsync(userDTO.UserName, userDTO.Password, false, false);
                    if (signInManagerResult.Succeeded == false)
                    {
                        ModelState.AddModelError("", "Something went wrong during login. Please try again./n" +
                            "If the problem persists, contact support.");
                        return View((returnUrl, userDTO));
                    }
                    TempData["UserDTO"] = JsonSerializer.Serialize(userDTO);
                    return RedirectToAction("LoginSuccessfull", new { returnUrl });
                }
                else
                {
                    ModelState.AddModelError("", loginResult.Message);
                    return View((returnUrl, userDTO));
                }
            }
            else
            {
                ModelState.AddModelError("", "Please check the highlighted fields and try again.");
                return View((returnUrl, userDTO));
            }
        }

        public IActionResult LoginSuccessfull([FromQuery] string returnUrl)
        {
            return View((object)returnUrl);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.RegisterAsync(userDTO, false);

                if (result.RegisterStatus == RegisterStatus.Success)
                {
                    return View("RegisterSuccessfull", userDTO);
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(userDTO);
                }
            }
            else
            {
                ModelState.AddModelError("", "Please check the highlighted fields and try again.");
                return View(userDTO);
            }
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string returnUrl = null)
        {
            return View((object)returnUrl);
        }
    }
}
