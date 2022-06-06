using System;
using Microsoft.Extensions.DependencyInjection;
using WeightControl.Services;
using WeightControl.Services.Interfaces;
using WeightControl.ViewModels;
using WeightControl.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeightControl
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider;
        
        public App()
        {
            var services = new ServiceCollection();
            services.AddTransient<INavigationService,NavigationService>();
            services.AddTransient<ICurrentUserService,CurrentUserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IBackendClient, BackendClient>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<StatsViewModel>();
            
            ServiceProvider = services.BuildServiceProvider();

            InitializeComponent();
            MainPage = new AppShell();
        }

        protected async override void OnStart()
        {
            var currentUserService = ServiceProvider.GetRequiredService<ICurrentUserService>();
            var navigationService = ServiceProvider.GetRequiredService<INavigationService>();
            //var authenticationService = ServiceProvider.GetRequiredService<IAuthenticationService>();
            if (currentUserService.IsSignedIn)
            {
                await navigationService.NavigateToHomeAsync();
            }
            else
            {
                await navigationService.NavigateToLoginAsync();
            }  
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
