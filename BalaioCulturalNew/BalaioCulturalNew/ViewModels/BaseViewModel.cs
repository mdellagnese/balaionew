using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;
        protected IEventAggregator _eventAggregator;
        
        public BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _eventAggregator = eventAggregator;
        }

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public BaseViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
        }

        public BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }

        public BaseViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public void NavigateToUri(string uriText)
        {
            if (uriText != null)
                _navigationService.NavigateAsync(uriText);
        }
    }
}
