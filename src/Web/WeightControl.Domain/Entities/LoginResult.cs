using WeightControl.Domain.Enums;

namespace WeightControl.Domain.Entities
{
    public class LoginResult
    {
        public bool Succeded { get; set; }
        public LoginError Error { get; set; }
    }
}