using Entities.AuthModels;
using Entities.DataTransferObjects.Auth;

namespace Services.Contracts
{
    public interface IAuthService
    {
        Task<RegisterResult> RegisterAsync(RegisterUserDTO userDTO, bool trackChanges);
        Task<LoginResult> LoginAsync(LoginUserDTO userDTO, bool TrackChanges);
    }
}
