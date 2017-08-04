using Prism.Commands;
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

        public BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public void NavigateToUri(string uriText)
        {
            if (uriText != null)
                _navigationService.NavigateAsync(uriText);
        }
    }
}
