using System;
using System.Collections.Generic;
using WeightControl.ViewModels;
using Xamarin.Forms;

namespace WeightControl.Views
{
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }
}
