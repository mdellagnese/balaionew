using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Login
{
    public class RegisterPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public RegisterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
