﻿using Prism.Commands;
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
        public DelegateCommand<string> EventSelectedCommand { get; private set; }

        public FeedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Events = new ObservableCollection<string> { "Teste", "Teste 2", "Teste 2" };
            EventSelectedCommand = new DelegateCommand<string>((selectedEvent) => {
                var parameters = new NavigationParameters
                {
                    { "Title", selectedEvent }
                };

                navigationService.NavigateAsync("EventDetailPage", parameters, false);
            });
        }
        

        private ObservableCollection<String> _events;

        public ObservableCollection<string> Events
        {
            get { return _events; }
            set { SetProperty(ref _events, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine("Load Events");
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

    }
}
