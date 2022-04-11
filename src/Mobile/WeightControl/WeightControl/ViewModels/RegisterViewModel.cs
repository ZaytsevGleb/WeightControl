    using System;
using System.ComponentModel;
using System.Threading.Tasks;
using WeightControl.Services;
using Xamarin.Forms;

namespace WeightControl.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        private readonly NavigationService navigationService;
        private readonly CurrentUserService currentUserService;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool NameEmpty { get; set; }
        public bool EmailEmpty { get; set; }
        public bool PasswordEmpty { get; set; }

        public Command SignUpCommand { get; set; }
        public Command GoBackCommand { get; set; }

        public RegisterViewModel()
        {
            navigationService = new NavigationService();
            currentUserService = new CurrentUserService();

            SignUpCommand = new Command(async () => await SignUpAsync());
            GoBackCommand = new Command(async () => await GoBack());

            NameEmpty = false;
            EmailEmpty = false;
            PasswordEmpty = false;
        }

        public async Task GoBack()
        {
            await navigationService.NavigateToLoginAsync();
        }

        public async Task SignUpAsync()
        {
            if (Validate())
            {
                currentUserService.IsRegistered = true;
                await navigationService.NavigateToLoginAsync();
            }
            else
            {
                RisePropertyChanged(nameof(NameEmpty));
                RisePropertyChanged(nameof(EmailEmpty));
                RisePropertyChanged(nameof(PasswordEmpty));
            }
        }

        private bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(Name))
            {
                NameEmpty = true;
                isValid = false;
            }
            else
            {
                NameEmpty = false;
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
