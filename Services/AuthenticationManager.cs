using Entities.AuthModels;
using Entities.DataTransferObjects.Auth;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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

            var user = await _repositoryManager.User.FindByConditionAsync(u => u.UserName == userDTO.UserName || u.Email == userDTO.Email, trackChanges);
            if (user == null)
            {
                loginResult.LoginStatus = LoginStatus.UserNotFound;
                loginResult.Message = "User Not Found";
                return loginResult;
            }
            if (user.PasswordHash != userDTO.Password)
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
                        PasswordHash = userDTO.Password,
                        PhoneNumber = userDTO.Telephone,
                        Email = userDTO.Email,
                        NormalizedEmail = userDTO.Email.ToUpper(),
                        Role_Name = "User",
                        Salary = 20000,
                        Status = true
                    };

                    await _repositoryManager.User.CreateAsync(user);
                    await _repositoryManager.SaveAsync();
                    await _userManager.AddToRoleAsync(user, user.Role_Name);
                    await _repositoryManager.SaveAsync();

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

        private async Task<string> CreateTokenAsync(User user)
        {
            var signingCredentials = GetSigningCredentials(user);
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            return new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expirationInMinutes"])),
                signingCredentials: signingCredentials);
        }
    }
}
