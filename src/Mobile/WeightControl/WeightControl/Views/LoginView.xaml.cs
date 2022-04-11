using System;
using System.Collections.Generic;
using WeightControl.ViewModels;
using Xamarin.Forms;

namespace WeightControl.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
