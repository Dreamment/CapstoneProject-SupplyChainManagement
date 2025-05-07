namespace Entities.Enums
{
    public enum LoginStatus
    {
        Success,
        WrongPassword,
        UserNotFound,
        TwoFactorRequired,
        AccountDisabled,
        UnknownError
    }
}
