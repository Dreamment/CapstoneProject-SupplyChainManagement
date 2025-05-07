namespace Entities.Enums
{
    public enum RegisterStatus
    {
        Success,
        InvalidEmail,
        UsernameAlreadyExists,
        TelephoneAlreadyExists,
        EmailAlreadyExists,
        PasswordsDoesntMatch,
        WeakPassword,
        UnknownError
    }

}
