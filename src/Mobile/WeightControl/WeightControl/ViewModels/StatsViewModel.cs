using System;
using WeightControl.Services;

namespace WeightControl.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly ICurrentUserService currentUserService;
        
        public StatsViewModel(
            INavigationService navigationService,
            ICurrentUserService currentUserService)
        {
            this.navigationService = navigationService;
            this.currentUserService = currentUserService;
        }
    }
}
