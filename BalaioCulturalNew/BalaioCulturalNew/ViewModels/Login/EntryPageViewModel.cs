using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalaioCulturalNew.ViewModels.Login
{
	public class EntryPageViewModel : BaseViewModel
	{
        string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand NavigateToMainMenuCommand { get; private set; }
        public DelegateCommand FacebookLoginCommand { get; private set; }
        public DelegateCommand NavigateToRegisterPageCommand { get; private set; }
        public DelegateCommand NavigateToForgotPageCommand { get; private set; }

        bool LoginCommandCanExecute() =>
            !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);

        public EntryPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            //Adicionar ObservesProperty para o preenchimento do form
            NavigateToMainMenuCommand = new DelegateCommand(Logon, LoginCommandCanExecute)
                .ObservesProperty(() => Username)
                .ObservesProperty(() => Password);

            FacebookLoginCommand = new DelegateCommand(() => _navigationService.NavigateAsync("FacebookLoginPage",null,true));
            NavigateToRegisterPageCommand = new DelegateCommand(() => _navigationService.NavigateAsync("RegisterPage"));
            NavigateToForgotPageCommand = new DelegateCommand(async () => await _pageDialogService.DisplayAlertAsync("Aguarde", "Estamos trabalhando nisso :)", "OK"));
        }

        Action Logon
        {
            get
            {
                return new Action(async () => await VerifyUserInfo());
            }
        }
        
		public async Task VerifyUserInfo()
        {
            try
            {
                if (Username == "admin" && Password == "admin")
                {
                    // NAVEGAÇÃO ABSOLUTA POR URI
                    await _navigationService.NavigateAsync("balaio:///MainPage");
                    
                }
                else if (Username != "admin" || (Username == "admin" && Password != "admin"))
                {
                    await _pageDialogService.DisplayAlertAsync("Erro", "Usuário/Senha inválido.", "OK");
                }
                else if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    await _pageDialogService.DisplayAlertAsync("Erro", "Você precisa informar seus dados.", "OK");
                }
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Erro", ex.Message, "OK");
            }
        }
    }
}
