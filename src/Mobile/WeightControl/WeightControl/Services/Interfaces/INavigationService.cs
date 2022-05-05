using System.Threading.Tasks;

namespace WeightControl.Services
{
    public interface INavigationService
    {
        Task NavigateToLoginAsync(string login = "", string password = "");
        Task NavigateToRegisterAsync(string login = "", string password = "");
        Task NavigateToHomeAsync();
    }
    
}