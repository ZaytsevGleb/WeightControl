using System;
using System.ComponentModel;
using System.Threading.Tasks;
using WeightControl.Services;
using Xamarin.Forms;

namespace WeightControl.ViewModels
{
    [QueryProperty(nameof(Name), nameof(Name))]
    [QueryProperty(nameof(Password), nameof(Password))]
    public class LoginViewModel : BaseViewModel
    {
        private readonly NavigationService navigationService;
        private readonly CurrentUserService currentUserService;

        public string Name { get; set; }
        public string Password { get; set; }
        public bool NameEmpty { get; set; }
        public bool PasswordEmpty { get; set; }

        public Command GoToLoginCommand { get; set; }
        public Command GoToRegisterCommand { get; set; }

        public LoginViewModel()
        {
            navigationService = new NavigationService();
            currentUserService = new CurrentUserService();

            GoToLoginCommand = new Command(async () => await GoToLoginAsync());
            GoToRegisterCommand = new Command(async () => await GoToRegisterAsync());
        }

        public async Task GoToRegisterAsync()
        {
            await navigationService.NavigateToRegisterAsync(Name, Password);
        }

        public async Task GoToLoginAsync()
        {
            if (Validate())
            {
                currentUserService.IsRegistered = true;
                await navigationService.NavigateToHomeAsync();
            }
        }

        private bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(Name))
            {
                NameEmpty = true;
                isValid = false;
            }
            else
            {
                NameEmpty = false;
            }

            if (string.IsNullOrWhiteSpace(Password))
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