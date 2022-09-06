namespace WeightControl.Domain.Enums
{
    public enum RegisterError
    { 
        NameIsNullOrEmpty = 0,
        EmailIsNullOrEmpty = 1, 
        PasswordIsNullOrEmpty = 2,
        SuchUserAlreadyExists = 3,
    }
}   