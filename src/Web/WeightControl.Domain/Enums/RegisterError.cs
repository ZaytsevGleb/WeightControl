namespace WeightControl.Domain.Enums
{
    public enum RegisterError
    { 
        LoginIsNullOrEmpty = 0,
        EmailIsNullOrEmpty = 1, 
        PasswordIsNullOrEmpty = 2,
        SuchUserAlreadyExists = 3
    }
}