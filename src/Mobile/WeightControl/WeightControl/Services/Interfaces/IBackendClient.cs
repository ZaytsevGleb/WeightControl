using System.Threading.Tasks;

namespace WeightControl.Services
{
    public interface IBackendClient
    {
        Task<TResult> PostAsync<TResult>(string endpoint, object content);
    }
}