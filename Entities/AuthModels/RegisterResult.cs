using Entities.Enums;

namespace Entities.AuthModels
{
    public class RegisterResult
    {
        public RegisterStatus RegisterStatus { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
