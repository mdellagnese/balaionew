using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Feed
{
    public class FeedPageViewModel : BaseViewModel
    {
        public DelegateCommand EventSelectedCommand { get; private set; }

        public FeedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Events = new ObservableCollection<string> { "Teste", "Teste 2", "Teste 2" };
            EventSelectedCommand = new DelegateCommand(SelectEvent);
        }

        private void SelectEvent()
        {
            Debug.WriteLine("Evento Selecionado");
        }

        private ObservableCollection<String> _events;

        public ObservableCollection<string> Events
        {
            get { return _events; }
            set { SetProperty(ref _events, value); }
        }

    }
}
