using WeightControl.Domain.Enums;

namespace WeightControl.Application.Auth.Models
{
    public class RegisterResultDto
    {
        public bool Succeded { get; set; }

        public RegisterError Error { get; set; }
    }
}