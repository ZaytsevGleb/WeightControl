using System;
using System.Threading.Tasks;

namespace WeightControl.Services
{
    public interface IAuthenticationService
    {
        Task <bool> LoginAsync(string name, string password);
       Task <bool> RegisterAsync(string name, string password, string mail);
    }
}
