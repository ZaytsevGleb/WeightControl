namespace WeightControl.Models
{
    public enum RegisterError
    { 
        LoginIsNullOrEmpty = 0,
        EmailIsNullOrEmpty = 1, 
        PasswordIsNullOrEmpty = 2,
        SuchUserAlreadyExists = 3,
        AllFieldsAreNullOrEmpty = 4
    }
}