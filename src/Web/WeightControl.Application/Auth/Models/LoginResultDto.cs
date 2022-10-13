using WeightControl.Domain.Enums;

namespace WeightControl.Application.Auth.Models
{
    public class LoginResultDto
    {
        public bool Succeded { get; set; }
        public LoginError? Error { get; set; }
        public string Token { get; set; }
    }
}