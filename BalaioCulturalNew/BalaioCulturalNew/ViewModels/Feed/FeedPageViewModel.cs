using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Feed
{
    public class FeedPageViewModel : BaseViewModel
    {
        public FeedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Events = new ObservableCollection<string> { "Teste" };
        }

        private ObservableCollection<String> _events;

        public ObservableCollection<string> Events
        {
            get { return _events; }
            set { SetProperty(ref _events, value); }
        }

    }
}
