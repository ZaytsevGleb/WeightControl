using System;
using WeightControl.Services;

namespace WeightControl.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly ICurrentUserService currentUserService;
        
        public ProductsViewModel(
            INavigationService navigationService,
            ICurrentUserService currentUserService)
        {
            this.navigationService = navigationService;
            this.currentUserService = currentUserService;
        }
    }
}
