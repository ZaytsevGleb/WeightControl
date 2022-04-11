using System;
using WeightControl.Services;
using WeightControl.ViewModels;
using WeightControl.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeightControl
{
    public partial class App : Application
    {
        private readonly CurrentUserService currentUserService;
        private readonly NavigationService navigationService;

        public App()
        {
            navigationService = new NavigationService();
            currentUserService = new CurrentUserService();

            InitializeComponent();

            MainPage = new AppShell();

        }

        protected async override void OnStart()
        {
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
