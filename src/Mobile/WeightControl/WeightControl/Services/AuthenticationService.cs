using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeightControl.Models;
using Xamarin.Forms;

namespace WeightControl.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IBackendClient backendClient;
        // тоже в бекенд 
        private const string BackendHost = "https://476b-37-214-19-74.eu.ngrok.io";
        
        public AuthenticationService(IBackendClient backendClient)
        {
            this.backendClient = backendClient;
        }
        
        //Rename Login to LoginAsync
        public async Task<bool> Login(string name, string password)
        {
            
            //prepare obj to send
            var loginDto = new LoginDto()
            {
                Login = name,
                Password = password
            };
            var loginDtoResult = await backendClient.PostAsync<LoginResultDto>("auth/login", loginDto);
            
            // var json = JsonConvert.SerializeObject(loginDto);
            // var content = new StringContent(json, Encoding.UTF8, "application/json");
            //
            // //create client and send request
            // var client = new HttpClient();
            // var httpResponse = client.PostAsync(BackendHost + "/api/auth/login",content).GetAwaiter().GetResult();
            //
            // var stringModel = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //
            // var loginDtoResult = JsonConvert.DeserializeObject<LoginResultDto>(stringModel);
            return loginDtoResult.Succeded;
        }

        public bool Register(string name, string password, string mail)
        {
            return true;
        }
    }
}   