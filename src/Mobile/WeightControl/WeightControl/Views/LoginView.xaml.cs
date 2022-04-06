using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WeightControl.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginView();
        }
    }
}
