using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeightControl.Services.Interfaces;
using Newtonsoft.Json;
using WeightControl.Models;
using Xamarin.Forms.Internals;

namespace WeightControl.Services
{
    public class BackendClient : IBackendClient
    {
        private const string backendHost = "https://0f14-37-212-202-11.eu.ngrok.io";

        public async Task<TResult> PostAsync<TResult>(string endpoint, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var httpResponse = await client.PostAsync(backendHost + endpoint, jsonContent);
            // проверить нормально ли работает верхняя строчка с endpoint вместо значения /api/login и т/д/
            var stringModel = await httpResponse.Content.ReadAsStringAsync();
            var loginDtoResult = JsonConvert.DeserializeObject<TResult>(stringModel);
            return loginDtoResult;
        }
    }
}