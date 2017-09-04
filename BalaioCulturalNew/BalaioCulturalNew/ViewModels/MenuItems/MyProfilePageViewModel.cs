using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace BalaioCulturalNew.ViewModels.MenuItems
{
	public class MyProfilePageViewModel : BaseViewModel
	{
        private Uri _profileImageUrl;
        public Uri ProfileImageUrl
        {
            get { return _profileImageUrl; }
            set { SetProperty(ref _profileImageUrl, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        #region Commands
        public DelegateCommand SaveProfileCommand { get; private set; }

        #endregion

        public MyProfilePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            SaveProfileCommand = new DelegateCommand(SaveProfile);
        }

        private void SaveProfile()
        {
            Debug.WriteLine("Salvar Perfil");
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (Application.Current.Properties.ContainsKey("profile_image_url"))
                ProfileImageUrl = new Uri((string)Application.Current.Properties["profile_image_url"]);
            if (Application.Current.Properties.ContainsKey("user_full_name"))
                Name = (string)Application.Current.Properties["user_full_name"];
        }
    }
}
