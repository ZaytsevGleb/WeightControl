using WeightControl.Domain.Enums;

namespace WeightControl.Api.Models
{
    public class LoginResultDto
    {
        public bool Succeded { get; set; }
        
        public LoginError Error { get; set; }
    }
}