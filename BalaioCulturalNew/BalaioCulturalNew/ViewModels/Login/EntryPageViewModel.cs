using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Login
{
	public class EntryPageViewModel : BaseViewModel
	{
        public DelegateCommand NavigateToMainMenuCommand { get; private set; }

        public EntryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToMainMenuCommand = new DelegateCommand(() => _navigationService.NavigateAsync("MainPage", null, true));
        }
	}
}
