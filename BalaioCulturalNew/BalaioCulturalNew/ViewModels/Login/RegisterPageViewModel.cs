using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Login
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public DelegateCommand NavigateToEntryPageCommand { get; private set; }
        public DelegateCommand FacebookRegisterCommand { get; private set; }

        public RegisterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToEntryPageCommand = new DelegateCommand(() => _navigationService.GoBackAsync());
            FacebookRegisterCommand = new DelegateCommand(FacebookRegister);
        }

        private void FacebookRegister()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NeedRegistration", true);

            _navigationService.NavigateAsync("FacebookLoginPage", navParams, true);
        }
        
    }
}
