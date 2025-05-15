using Entities.Enums;

namespace Entities.AuthModels
{
    public class LoginResult
    {
        public LoginStatus LoginStatus { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
