using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using WeightControl.ViewModels;
using Xamarin.Forms;

namespace WeightControl.Views
{
    public partial class StatsView : ContentPage
    {
        public StatsView()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetRequiredService<StatsViewModel>();
        }
    }
}
