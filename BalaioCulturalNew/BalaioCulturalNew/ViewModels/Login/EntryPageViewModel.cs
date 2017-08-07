using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalaioCulturalNew.ViewModels.Login
{
	public class EntryPageViewModel : BaseViewModel
	{
        public DelegateCommand NavigateToMainMenuCommand { get; private set; }
        public DelegateCommand FacebookLoginCommand { get; private set; }
        public DelegateCommand NavigateToRegisterPageCommand { get; private set; }
        public DelegateCommand NavigateToForgotPageCommand { get; private set; }

        public EntryPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            //Adicionar ObservesProperty para o preenchimento do form
            NavigateToMainMenuCommand = new DelegateCommand(() => _navigationService.NavigateAsync("app:///MainPage"));

            FacebookLoginCommand = new DelegateCommand(() => _navigationService.NavigateAsync("FacebookLoginPage",null,true));
            NavigateToRegisterPageCommand = new DelegateCommand(() => _navigationService.NavigateAsync("RegisterPage"));
            NavigateToForgotPageCommand = new DelegateCommand(async () => await _pageDialogService.DisplayAlertAsync("Aguarde", "Estamos trabalhando nisso :)", "OK"));
        }
	}
}
