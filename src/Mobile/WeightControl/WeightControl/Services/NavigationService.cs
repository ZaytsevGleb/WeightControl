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
        }

        public async Task NavigateToSignInAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(SignInView)}");
        }

        public async Task NavigateToHomeAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
        }
    }
}
