using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Auth
{
    public class RegisterUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
