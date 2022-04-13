    using System;
using System.ComponentModel;
using System.Threading.Tasks;
using WeightControl.Services;
using Xamarin.Forms;

namespace WeightControl.ViewModels
{
    [QueryProperty(nameof(Login),nameof(Login))]
    [QueryProperty(nameof(Password), nameof(Password))]
    public class RegisterViewModel:BaseViewModel
    {
        private readonly NavigationService navigationService;
        private readonly CurrentUserService currentUserService;

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool LoginEmpty { get; set; }
        public bool EmailEmpty { get; set; }
        public bool PasswordEmpty { get; set; }

        public Command SignUpCommand { get; set; }

        public RegisterViewModel()
        {
            navigationService = new NavigationService();
            currentUserService = new CurrentUserService();

            SignUpCommand = new Command(async () => await SignUpAsync());
        }

        public async Task SignUpAsync()
        {
            if (Validate())
            {
                currentUserService.IsRegistered = true;
                await navigationService.NavigateToLoginAsync(Login,Password);
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

            if (string.IsNullOrEmpty(Email))
            {
                EmailEmpty = true;
                isValid = false;
            }
            else
            {
                EmailEmpty = false;
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
