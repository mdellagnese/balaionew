using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Login
{
    public class LoginPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public DelegateCommand NewAccountCommand { get; private set; }
        public DelegateCommand NavigateToEntryPageCommand { get; private set; }
        

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NewAccountCommand = new DelegateCommand(NavigateToRegister);
            NavigateToEntryPageCommand = new DelegateCommand(NavigateToEntry);
        }

        private void NavigateToRegister() {
            _navigationService.NavigateAsync("RegisterPage");
        }

        private void NavigateToEntry()
        {
            _navigationService.NavigateAsync("EntryPage");
        }
    }
}
