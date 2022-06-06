using System;
using WeightControl.Services.Interfaces;

namespace WeightControl.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public bool IsSignedIn { get; set; } = false;
        public bool IsRegistered { get; set; } = false;
    }
}