using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Login
{
	public class EntryPageViewModel : BindableBase
	{
        private INavigationService _navigationService;

        public EntryPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
	}
}
