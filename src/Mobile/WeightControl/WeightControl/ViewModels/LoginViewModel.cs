using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace WeightControl.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool LoginNameEmpty { get; set; }
        public bool LoginPasswordEmpty { get; set; }

        public Command SignInCommand { get; set; }

        public LoginViewModel()
        {
            SignInCommand = new Command(SignIn);

            LoginNameEmpty = false;
            RisePropertyChanged(nameof(LoginNameEmpty));

            LoginPasswordEmpty = false;
            RisePropertyChanged(nameof(LoginPasswordEmpty));
        }

        public void SignIn()
        {
            if (Validate())
            {

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
