using System;
using System.ComponentModel;
using System.Threading.Tasks;
using WeightControl.Services;
using Xamarin.Forms;

namespace WeightControl.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private readonly NavigationService navigationService;
        private readonly CurrentUserService currentUserService;

        public string Name { get; set; }
        public string Password { get; set; }
        public bool NameEmpty { get; set; }
        public bool PasswordEmpty { get; set; }

        public Command SignInCommand { get; set; }
        public Command GoToSignUpCommand { get; set; }

        public LoginViewModel()
        {
            navigationService = new NavigationService();
            currentUserService = new CurrentUserService();

            SignInCommand = new Command(async () => await SignInAsync());
            GoToSignUpCommand = new Command(async () => await GoToSignUp());

            NameEmpty = false;
            PasswordEmpty = false;            
        }

        public async Task GoToSignUp()
        {
            await navigationService.NavigateToRegisterAsync();
        }

        public async Task SignInAsync()
        {
            if (Validate())
            {
                currentUserService.IsRegistered = true;
                await navigationService.NavigateToHomeAsync();
            }
            else
            {
                RisePropertyChanged(nameof(PasswordEmpty));
                RisePropertyChanged(nameof(NameEmpty));
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
