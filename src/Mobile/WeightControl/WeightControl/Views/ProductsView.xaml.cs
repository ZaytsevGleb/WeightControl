using System;
using System.Collections.Generic;
using WeightControl.ViewModels;
using Xamarin.Forms;

namespace WeightControl.Views
{
    public partial class ProductsView : ContentPage
    {
        public ProductsView()
        {
            InitializeComponent();
            BindingContext = new ProductsViewModel();
        }
    }
}
