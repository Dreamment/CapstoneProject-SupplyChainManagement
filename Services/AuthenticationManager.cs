using Entities.AuthModels;
using Entities.DataTransferObjects.Auth;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contracts;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class AuthenticationManager : IAuthService
    {
        private readonly IRepositoryManager _repositoryManager;
        //private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationManager(
            IRepositoryManager repositoryManager,
            //RoleManager<IdentityRole<Guid>> roleManager,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _configuration = configuration;
            //_roleManager = roleManager;
        }

        public async Task<LoginResult> LoginAsync(LoginUserDTO userDTO, bool trackChanges)
        {
            LoginResult loginResult = new()
            {
                Email = userDTO.Email,
                UserName = userDTO.UserName,
            };

            var user = await _userManager.FindByNameAsync(userDTO.UserName);
            if (user == null)
            {
                loginResult.LoginStatus = LoginStatus.UserNotFound;
                loginResult.Message = "User Not Found";
                return loginResult;
            }
            if (await _userManager.CheckPasswordAsync(user, userDTO.Password) == false)
            {
                loginResult.LoginStatus = LoginStatus.WrongPassword;
                loginResult.Message = "Wrong Password";
                return loginResult;
            }
            if (!user.Status)
            {
                loginResult.LoginStatus = LoginStatus.AccountDisabled;
                loginResult.Message = "User Not Active";
                return loginResult;
            }
            loginResult.LoginStatus = LoginStatus.Success;
            loginResult.Message = "Login Success";

            return loginResult;
        }

        public async Task<RegisterResult> RegisterAsync(RegisterUserDTO userDTO, bool trackChanges)
        {
            RegisterResult registerResult = new()
            {
                Email = userDTO.Email,
                UserName = userDTO.UserName,
            };

            if (userDTO.Password != userDTO.ConfirmPassword)
            {
                registerResult.RegisterStatus = RegisterStatus.PasswordsDoesntMatch;
                registerResult.Message = "Passwords Doesn't Match";

                return registerResult;
            }

            var userByUsername = await _repositoryManager.User.FindByConditionAsync(u => u.UserName == userDTO.UserName, trackChanges);

            if (userByUsername == null)
            {
                var userByEmail = await _repositoryManager.User.FindByConditionAsync(u => u.Email == userDTO.Email, trackChanges);
                if (userByEmail == null)
                {
                    User user = new()
                    {
                        Id = Guid.NewGuid(),
                        UserName = userDTO.UserName,
                        NormalizedUserName = userDTO.UserName.ToUpper(),
                        PhoneNumber = userDTO.Telephone,
                        Email = userDTO.Email,
                        NormalizedEmail = userDTO.Email.ToUpper(),
                        Role_Name = "User",
                        Salary = 20000,
                        Status = true
                    };

                    var result = await _userManager.CreateAsync(user, userDTO.Password);
                    if (result.Succeeded)
                        await _userManager.AddToRoleAsync(user, user.Role_Name);
                    else
                    {
                        registerResult.RegisterStatus = RegisterStatus.UnknownError;
                        var errors = result.Errors.ToList();
                        registerResult.Message = string.Join(Environment.NewLine, errors.Select(e => e.Description));
                        var userByName2 = await _userManager.FindByEmailAsync(userDTO.Email);
                        if (userByName2 != null)
                            await _userManager.DeleteAsync(userByName2);

                        return registerResult;
                    }

                    registerResult.RegisterStatus = RegisterStatus.Success;
                    registerResult.Message = $"User with{user.UserName} username has enrolled to the system.";
                }
                else
                {
                    registerResult.RegisterStatus = RegisterStatus.EmailAlreadyExists;
                    registerResult.Message = $"{userDTO.Email} already used.";
                }
            }
            else
            {
                registerResult.RegisterStatus = RegisterStatus.UsernameAlreadyExists;
                registerResult.Message = $"{userDTO.UserName} already used.";
            }

            return registerResult;
        }
    }
}
