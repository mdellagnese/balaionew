using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Login
{
    public class FacebookLoginPageViewModel : BaseViewModel, INavigationAware
    {
        public FacebookLoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
        
    }
}
