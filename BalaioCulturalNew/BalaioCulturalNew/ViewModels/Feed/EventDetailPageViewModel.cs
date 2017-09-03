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
        public DelegateCommand AddToBalaioEventCommand { get; private set; }

        public EventDetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            RouteToEventCommand = new DelegateCommand(GetRouteToEvent);
            BuyTicketToEventCommand = new DelegateCommand(BuyTicketToEvent);
            ShareEventCommand = new DelegateCommand(ShareEvent);
            AddToBalaioEventCommand = new DelegateCommand(AddToBalaioEvent);
        }

        private void AddToBalaioEvent()
        {
            Debug.WriteLine("Chamar API passando o id do evento.");
        }

        private void BuyTicketToEvent()
        {
            Debug.WriteLine("Chamar o navegador com a URL");
        }

        private void ShareEvent()
        {
            Debug.WriteLine("Compartilhar Evento, como aonde?");
        }

        private void GetRouteToEvent()
        {
            Debug.WriteLine("Abrir no maps.");
        }
    }
}
