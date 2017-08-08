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
        public bool NeedRegistration { get; set; }

        public FacebookLoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("NeedRegistration"))
            {
                NeedRegistration = (bool)parameters["NeedRegistration"];
            }    
        }
        
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }
    }
}
