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
        public bool NameEmpty { get; set; }
        public bool EmailEmpty { get; set; }
        public bool PasswordEmpty { get; set; }

        public Command SignUpCommand { get; set; }

        public RegisterViewModel()
        {
            SignUpCommand = new Command(SignUp);

            NameEmpty = false;
            RisePropertyChanged(nameof(NameEmpty));

            EmailEmpty = false;
            RisePropertyChanged(nameof(EmailEmpty));

            PasswordEmpty = false;
            RisePropertyChanged(nameof(PasswordEmpty));
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
