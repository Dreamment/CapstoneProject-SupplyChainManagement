using Entities.AuthModels;
using Entities.DataTransferObjects.Auth;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MVCApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] RegisterUserDTO userDTO)
        {
            RegisterResult result = new();
            if (ModelState.IsValid)
            {
                result = Task.Run(() => _authenticationService.RegisterAsync(userDTO, false)).Result;
            }
            else
            {
                ModelState.AddModelError("", "Invalid data.");
                return View("Unsuccessfull", result);
            }

            if (result.RegisterStatus == RegisterStatus.Success)
            {
                return View("Successfull", userDTO);
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return View("Unsuccessfull", (result,userDTO));
            }
        }
    }
}
