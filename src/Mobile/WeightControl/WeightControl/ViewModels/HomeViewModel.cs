using System;
using WeightControl.Services;

namespace WeightControl.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly ICurrentUserService currentUserService;
        
        public HomeViewModel(
            INavigationService navigationService,
            ICurrentUserService currentUserService)
        {
            this.navigationService = navigationService;
            this.currentUserService = currentUserService;
        }
    }
}
