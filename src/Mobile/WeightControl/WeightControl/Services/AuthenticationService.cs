using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeightControl.Models;
using WeightControl.Services.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeightControl.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IBackendClient backendClient;

        public AuthenticationService(IBackendClient backendClient)
        {
            this.backendClient = backendClient;
        }

        public async Task<bool> LoginAsync(string name, string password)
        {
            //prepare obj to send
            var loginDto = new LoginDto()
            {
                Login = name,
                Password = password
            };
            
            var loginDtoResult = await backendClient.PostAsync<LoginResultDto>("/api/auth/login", loginDto);
            return loginDtoResult.Succeded;
        }

        public async Task<bool> RegisterAsync(string name, string password, string mail)
        {
            var registerDto = new RegisterDto()
            {
                Login = name,
                Password = password,
                Email = mail 
            };

            var registerDtoResult = await backendClient.PostAsync<RegisterResultDto>("/api/auth/register", registerDto);
            return registerDtoResult.Succeded;
        }
    }
}   