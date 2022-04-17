using System;
using WeightControl.Services;

namespace WeightControl.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly ICurrentUserService currentUserService;
        private readonly IAuthenticationService authenticationService;
        
        public HomeViewModel(
            INavigationService navigationService,
            ICurrentUserService currentUserService,
            IAuthenticationService authenticationService)
        {
            this.navigationService = navigationService;
            this.currentUserService = currentUserService;
            this.authenticationService = authenticationService;
        }
    }
}
