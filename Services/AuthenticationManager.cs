using Entities.AuthModels;
using Entities.DataTransferObjects.Auth;
using Entities.Enums;
using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contratcs;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AuthenticationManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<LoginResult> LoginAsync(LoginUserDTO userDTO, bool trackChanges)
        {
            LoginResult loginResult = new()
            {
                Email = userDTO.Email,
                UserName = userDTO.UserName,
            };

            var user = await _repositoryManager.User.FindByConditionAsync(u => u.User_Name == userDTO.UserName || u.E_Mail == userDTO.Email, trackChanges);
            if (user == null)
            {
                loginResult.LoginStatus = LoginStatus.UserNotFound;
                loginResult.Message = "User Not Found";
                return loginResult;
            }
            if (user.Password != userDTO.Password)
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
            loginResult.Token = await CreateTokenAsync(user);

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

            var userByUsername = await _repositoryManager.User.FindByConditionAsync(u => u.User_Name == userDTO.UserName, trackChanges);

            if (userByUsername == null)
            {
                var userByEmail = await _repositoryManager.User.FindByConditionAsync(u => u.E_Mail == userDTO.Email, trackChanges);
                if (userByEmail == null)
                {
                    User user = new()
                    {
                        User_Name = userDTO.UserName,
                        Password = userDTO.Password,
                        Telephone = userDTO.Telephone,
                        E_Mail = userDTO.Email,
                        Role_Name = "User",
                        Salary = 20000,
                        Status = true
                    };

                    await _repositoryManager.User.CreateAsync(user);
                    await _repositoryManager.SaveAsync();

                    registerResult.RegisterStatus = RegisterStatus.Success;
                    registerResult.Message = $"User with{user.User_Name} username has enrolled to the system.";
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

        private async Task<string> CreateTokenAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your_secret_key_here"); // Replace with your actual secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, user.User_Name),
                    new Claim(ClaimTypes.Email, user.E_Mail),
                    new Claim(ClaimTypes.Role, user.Role_Name)
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
