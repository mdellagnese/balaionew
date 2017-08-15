using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Feed
{
    public class EventDetailPageViewModel : BaseViewModel
    {
        public EventDetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }
    }
}
