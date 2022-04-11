using System;
namespace WeightControl.Services
{
    public class CurrentUserService
    {
        public bool IsSignedIn { get; set; } = false;
        public bool IsRegistered { get; set; } = false;
    }
}