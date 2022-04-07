using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using WeightControl.Services;

namespace WeightControl.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private readonly NavigationService navigationService;
        public string Name { get; set; }
        public string Password { get; set; }
        public bool LoginNameEmpty { get; set; }
        public bool LoginPasswordEmpty { get; set; }

        public Command SignInCommand { get; set; }

        public LoginViewModel()
        {
            navigationService = new NavigationService();

            SignInCommand = new Command(async () => await SignInAsync());

            LoginNameEmpty = false;
            RisePropertyChanged(nameof(LoginNameEmpty));

            LoginPasswordEmpty = false;
            RisePropertyChanged(nameof(LoginPasswordEmpty));

        }

        public async Task SignInAsync()
        {
            if (Validate())
            {
                await navigationService.NavigateToHomeAsync();
            }
        }

        private bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(Name))
            {
                LoginNameEmpty = true;
                isValid = false;
            }
            else
            {
                LoginNameEmpty = false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                LoginPasswordEmpty = true;
                isValid = false;
            }
            else
            {
                LoginPasswordEmpty = false;
            }

            return isValid;
        }
    }
}
