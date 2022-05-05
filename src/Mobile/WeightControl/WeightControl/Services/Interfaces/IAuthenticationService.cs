using System;
namespace WeightControl.Services
{
    public interface IAuthenticationService
    {
        bool Login(string name, string password);
        bool Register(string name, string password, string mail);
    }
}
