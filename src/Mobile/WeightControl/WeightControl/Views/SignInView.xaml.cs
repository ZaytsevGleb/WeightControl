using System;
using System.Collections.Generic;
using WeightControl.ViewModels;
using Xamarin.Forms;

namespace WeightControl.Views
{
    public partial class SignInView : ContentPage
    {
        public SignInView()
        {
            InitializeComponent();
            BindingContext = new SignInviewModel();
        }
    }
}
