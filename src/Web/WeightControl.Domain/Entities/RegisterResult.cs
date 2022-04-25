using WeightControl.Domain.Enums;

namespace WeightControl.Domain.Entities
{
    public class RegisterResult
    {
        public bool Succeded { get; set; }
        
        public RegisterError Error { get; set; } 
    }
}