using BalaioCulturalNew.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace BalaioCulturalNew.ViewModels.Templates
{

    public class MainMenuPageViewModel : BaseViewModel
    {
        #region Properties
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

        private ObservableCollection<CustomMenuItem> _menuItems;
        public ObservableCollection<CustomMenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        #endregion

        #region Commands
        public DelegateCommand<CustomMenuItem> MenuSelectedCommand { get; private set; }
        
        #endregion

        public MainMenuPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            MenuItems = GetMenus();

            if (Application.Current.Properties.ContainsKey("profile_image_url"))
                ProfileImageUrl = new Uri((string)Application.Current.Properties["profile_image_url"]);
            if (Application.Current.Properties.ContainsKey("user_full_name"))
                Name = (string)Application.Current.Properties["user_full_name"];

            MenuSelectedCommand = new DelegateCommand<CustomMenuItem>(async (selectedMenu) => {
                if(selectedMenu.Text == "Sair")
                {
                    var logoff = await _pageDialogService.DisplayAlertAsync("Balaio Cultural"," Deseja realmente sair da sua conta?", "Sim", "Não");

                    if(logoff == true)
                    {
                        var parameters = new NavigationParameters
                        {
                            { "logoff", true }
                        };

                        _navigationService.NavigateAsync(selectedMenu.Uri, parameters);
                    }
                }
                else
                {
                    _navigationService.NavigateAsync(selectedMenu.Uri, null, true);
                }
                
            });
        }

        #region Methods
        private ObservableCollection<CustomMenuItem> GetMenus()
        {
            var Menus = new ObservableCollection<CustomMenuItem>();
            Menus.Add(new CustomMenuItem { Text = "Editar Perfil", Uri = "NavigationPage/MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Alterar Localização", Uri = "MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Contato", Uri = "ContactPage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Quero Anunciar", Uri = "MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Política e Privacidade", Uri = "MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Sair", Uri = "app:///EntryPage", Icon = "" });

            return Menus;
        }
        #endregion
    }
}
