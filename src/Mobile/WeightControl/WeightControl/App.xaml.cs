using System;
using Microsoft.Extensions.DependencyInjection;
using WeightControl.Services;
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
            services.AddSingleton<INavigationService,NavigationService>();
            services.AddTransient<ICurrentUserService,CurrentUserService>();

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
            var currentUserService = ServiceProvider.GetRequiredService<CurrentUserService>();
            var navigationService = ServiceProvider.GetRequiredService<NavigationService>();
            if(currentUserService.IsSignedIn)
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
