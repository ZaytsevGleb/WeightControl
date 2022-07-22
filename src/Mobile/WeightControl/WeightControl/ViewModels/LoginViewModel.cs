using System;
using System.ComponentModel;
using System.Threading.Tasks;
using WeightControl.Services;
using WeightControl.Services.Interfaces;
using Xamarin.Forms;

namespace WeightControl.ViewModels
{
    [QueryProperty(nameof(Login), nameof(Login))]
    [QueryProperty(nameof(Password), nameof(Password))]
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly ICurrentUserService currentUserService;
        private readonly IAuthenticationService authenticationService;
        
        public string Login { get; set; }
        public string Password { get; set; }
        public bool LoginEmpty { get; set; }
        public bool PasswordEmpty { get; set; }

        public Command GoToLoginCommand { get; set; }
        public Command GoToRegisterCommand { get; set; }

        public LoginViewModel(
            INavigationService navigationService,
            ICurrentUserService currentUserService,
            IAuthenticationService authenticationService)
        {
            this.navigationService = navigationService;
            this.currentUserService = currentUserService;
            this.authenticationService = authenticationService;

            GoToLoginCommand = new Command(async () => await GoToLoginAsync());
            GoToRegisterCommand = new Command(async () => await GoToRegisterAsync());
        }

        public async Task GoToRegisterAsync()
        {
            await navigationService.NavigateToRegisterAsync(Login, Password);
        }

        public async Task GoToLoginAsync()
        {
            if (Validate())
            {
                if (await authenticationService.LoginAsync(Login,Password))
                {
                    currentUserService.IsRegistered = true;
                    await navigationService.NavigateToHomeAsync();
                }
            }
        }

        private bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(Login))
            {
                LoginEmpty = true;
                isValid = false;
            }
            else
            {
                LoginEmpty = false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                PasswordEmpty = true;
                isValid = false;
            }
            else
            {
                PasswordEmpty = false;
            }

            return isValid;
        }
    }
}