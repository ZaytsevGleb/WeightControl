using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace WeightControl.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RegisterNameEmpty { get; set; }
        public bool RegisterEmailEmpty { get; set; }
        public bool RegisterPasswordEmpty { get; set; }

        public Command SignUpCommand { get; set; }

        public RegisterViewModel()
        {
            SignUpCommand = new Command(SignUp);

            RegisterNameEmpty = false;
            RisePropertyChanged(nameof(RegisterNameEmpty));

            RegisterEmailEmpty = false;
            RisePropertyChanged(nameof(RegisterEmailEmpty));

            RegisterPasswordEmpty = false;
            RisePropertyChanged(nameof(RegisterPasswordEmpty));
        }

        public void SignUp()
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
                RegisterNameEmpty = true;
                isValid = false;
            }
            else
            {
                RegisterNameEmpty = false;
            }

            if (string.IsNullOrEmpty(Email))
            {
                RegisterEmailEmpty = true;
                isValid = false;
            }
            else
            {
                RegisterEmailEmpty = false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                RegisterPasswordEmpty = true;
                isValid = false;
            }
            else
            {
                RegisterPasswordEmpty = false;
            }

            return isValid;
        }
    }
}
