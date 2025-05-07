namespace Entities.DataTransferObjects.Auth
{
    public class LoginUserDTO
    {

        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public bool IsEmail { get; set; } = false;
    }
}
