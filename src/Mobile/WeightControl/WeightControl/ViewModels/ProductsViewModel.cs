using System;
using WeightControl.Services;
using WeightControl.Services.Interfaces;

namespace WeightControl.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly ICurrentUserService currentUserService;
        private readonly IAuthenticationService authenticationService;
        
        public ProductsViewModel(
            INavigationService navigationService,
            ICurrentUserService currentUserService,
            AuthenticationService authenticationService)
        {
            this.navigationService = navigationService;
            this.currentUserService = currentUserService;
            this.authenticationService = authenticationService;
        }
    }
}
