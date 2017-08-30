using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;

namespace BalaioCulturalNew.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IEventAggregator eventAggregator) : base(navigationService, pageDialogService, eventAggregator)
        {
            
        }
    }
}
