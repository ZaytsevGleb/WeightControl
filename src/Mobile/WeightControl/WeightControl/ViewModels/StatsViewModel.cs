using System;
using WeightControl.Services;
using WeightControl.Services.Interfaces;

namespace WeightControl.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly ICurrentUserService currentUserService;
        private readonly IAuthenticationService authenticationService;
        
        public StatsViewModel(
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
