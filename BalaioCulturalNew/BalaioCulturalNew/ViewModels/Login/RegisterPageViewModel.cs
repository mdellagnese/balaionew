using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace BalaioCulturalNew.ViewModels.Login
{
    public class RegisterPageViewModel : BaseViewModel
    {
        #region Properties 
        private bool _showModalCities;
        public bool ShowModalCities
        {
            get { return _showModalCities; }
            set
            {
                SetProperty(ref _showModalCities, value);
            }
        }

        private ObservableCollection<string> _availableCities;
        public ObservableCollection<string> AvailableCities
        {
            get { return _availableCities; }
            set { SetProperty(ref _availableCities, value); }
        }
        #endregion

        public DelegateCommand NavigateToEntryPageCommand { get; private set; }
        public DelegateCommand FacebookRegisterCommand { get; private set; }

        public RegisterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToEntryPageCommand = new DelegateCommand(() => _navigationService.GoBackAsync());
            FacebookRegisterCommand = new DelegateCommand(FacebookRegister);

            AvailableCities = new ObservableCollection<string> { "Porto Alegre", "São Paulo" };

            ShowModalCities = true;
        }

        private void FacebookRegister()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NeedRegistration", true);

            _navigationService.NavigateAsync("FacebookLoginPage", navParams, true);
        }
        
    }
}
