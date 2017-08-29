using Prism.Commands;
using Prism.Mvvm;
using System;
using Xamarin.Forms;

namespace BalaioCulturalNew.ViewModels.Templates
{
    public class MainMenuPageViewModel : BindableBase
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

        public MainMenuPageViewModel()
        {
            ProfileImageUrl = new Uri((string)Application.Current.Properties["profile_image_url"]);
            Name = (string)Application.Current.Properties["user_full_name"];
        }
	}
}
