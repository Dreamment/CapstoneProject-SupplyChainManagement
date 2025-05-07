using Entities.AuthModels;
using Entities.DataTransferObjects.Auth;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MVCApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] LoginUserDTO userDTO)
        {
            LoginResult result = new();
            if (ModelState.IsValid)
            {
                result = Task.Run(() => _authenticationService.LoginAsync(userDTO, false)).Result;
            }
            else
            {
                ModelState.AddModelError("", "Invalid data.");
                return View("Unsuccessfull", result);
            }

            if (result.LoginStatus == LoginStatus.Success)
            {
                return View("Successfull", userDTO);
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return View("Unsuccessfull", (result, userDTO));

            }
        }
    }
}
