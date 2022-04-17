using System;
using System.Threading.Tasks;
using WeightControl.ViewModels;
using WeightControl.Views;
using Xamarin.Forms;

namespace WeightControl.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(StatsView), typeof(StatsView));
            Routing.RegisterRoute(nameof(ProductsView), typeof(ProductsView));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
        }

        public async Task NavigateToLoginAsync(string login = "", string password = "")
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginView)}?{nameof(LoginViewModel.Login)}={login}&{nameof(LoginViewModel.Password)}={password}");
        }

        public async Task NavigateToRegisterAsync(string login = "", string password = "")
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginView)}/{nameof(RegisterView)}?{nameof(RegisterViewModel.Login)}={login}&{nameof(RegisterViewModel.Password)}={password}");
        }

        public async Task NavigateToHomeAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
        }
        
    }
}
