using BalaioCulturalNew.Events;
using BalaioCulturalNew.Models;
using BalaioCulturalNew.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
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
        public DelegateCommand NavigateToProfileCommand { get; private set; }
        public DelegateCommand NavigateToLocationCommand { get; private set; }
        public DelegateCommand NavigateToContactCommand { get; private set; }
        public DelegateCommand NavigateToAnnounceCommand { get; private set; }
        public DelegateCommand NavigateToPrivacyCommand { get; private set; }
        #endregion
        
        public MainMenuPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            MenuItems = GetMenus();

            if (Application.Current.Properties.ContainsKey("profile_image_url"))
                ProfileImageUrl = new Uri((string)Application.Current.Properties["profile_image_url"]);
            if (Application.Current.Properties.ContainsKey("user_full_name"))
                Name = (string)Application.Current.Properties["user_full_name"];

            NavigateToProfileCommand = new DelegateCommand(() => {
                _eventAggregator.GetEvent<NavigateFromMenuEvent>().Publish("MyProfilePage");
            });

            NavigateToContactCommand = new DelegateCommand(() => {
                _eventAggregator.GetEvent<NavigateFromMenuEvent>().Publish("ContactPage");
            });
        }

        private ObservableCollection<CustomMenuItem> GetMenus()
        {
            var Menus = new ObservableCollection<CustomMenuItem>();
            Menus.Add(new CustomMenuItem { Text = "Editar Perfil", Uri = "MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Alterar Localização", Uri = "MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Contato", Uri = "MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Quero Anunciar", Uri = "MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Política e Privacidade", Uri = "MyProfilePage", Icon = "" });
            Menus.Add(new CustomMenuItem { Text = "Sair", Uri = "MyProfilePage", Icon = "" });

            return Menus;
        }
    }
}
