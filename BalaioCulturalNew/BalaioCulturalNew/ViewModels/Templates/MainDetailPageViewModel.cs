using BalaioCulturalNew.Events;
using BalaioCulturalNew.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Templates
{
    public class MainDetailPageViewModel : BaseViewModel
    {
        public MainDetailPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            eventAggregator.GetEvent<NavigateFromMenuEvent>().Subscribe(NavigateToUri);
        }

        private void NavigateToUri(string uri)
        {
            if (uri != null)
            {
                var masterPage = App.Current.MainPage as MainPage;
                masterPage.IsPresented = false;

                _navigationService.NavigateAsync(uri);
            }
        }
        
    }
}
