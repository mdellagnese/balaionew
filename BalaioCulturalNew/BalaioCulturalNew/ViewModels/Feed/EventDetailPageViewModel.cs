using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Feed
{
    public class EventDetailPageViewModel : BaseViewModel
    {
        public DelegateCommand RouteToEventCommand { get; private set; }
        public DelegateCommand BuyTicketToEventCommand { get; private set; }
        public DelegateCommand ShareEventCommand { get; private set; }

        public EventDetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            RouteToEventCommand = new DelegateCommand(GetRouteToEvent);
            BuyTicketToEventCommand = new DelegateCommand(BuyTicketToEvent);
            ShareEventCommand = new DelegateCommand(ShareEvent);
        }

        private void BuyTicketToEvent()
        {
            Debug.WriteLine("Here");
        }

        private void ShareEvent()
        {
            Debug.WriteLine("Here");
        }

        private void GetRouteToEvent()
        {
            Debug.WriteLine("Here");
        }
    }
}
