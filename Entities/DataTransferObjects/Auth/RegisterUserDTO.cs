using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Auth
{
    public class RegisterUserDTO
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
