using System;
using System.Threading.Tasks;
using WeightControl.Views;
using Xamarin.Forms;

namespace WeightControl.Services
{
    public class NavigationService
    {
        public NavigationService()
        {
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(StatsView), typeof(StatsView));
            Routing.RegisterRoute(nameof(ProductsView), typeof(ProductsView));
            Routing.RegisterRoute(nameof(SignInView), typeof(SignInView));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
        }

        public async Task NavigateToLoginAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }

        public async Task NavigateToHomeAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
        }
    }
}
