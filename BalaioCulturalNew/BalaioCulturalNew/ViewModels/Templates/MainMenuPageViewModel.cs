using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using Xamarin.Forms;

namespace BalaioCulturalNew.ViewModels.Templates
{
    public class MainMenuPageViewModel : BaseViewModel
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

        public DelegateCommand NavigateToProfileCommand { get; private set; }
        public DelegateCommand NavigateToLocationCommand { get; private set; }
        public DelegateCommand NavigateToContactCommand { get; private set; }
        public DelegateCommand NavigateToAnnounceCommand { get; private set; }
        public DelegateCommand NavigateToPrivacyCommand { get; private set; }
        
        public MainMenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            if(Application.Current.Properties.ContainsKey("profile_image_url"))
                ProfileImageUrl = new Uri((string)Application.Current.Properties["profile_image_url"]);
            if (Application.Current.Properties.ContainsKey("user_full_name"))
                Name = (string)Application.Current.Properties["user_full_name"];
            
            NavigateToProfileCommand = new DelegateCommand(NavigateToProfile);
        }

        private void NavigateToProfile()
        {
            NavigateToURI("MyProfilePage");
        }

        private void NavigateToURI(string uri)
        {
            if(uri != null)
            {
                _navigationService.NavigateAsync(uri);
            }
            
        }
        
    }
}
