using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DryIoc;
using Prism.DryIoc;
using Prism.Navigation;
using Android.Accounts;
using Xamarin.Auth;
using Prism.Events;
using BalaioCulturalNew.ViewModels.Login;

namespace BalaioCulturalNew.Droid
{
    [Activity(Label = "Balaio Cultural", Theme = "@style/MyTheme", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected IEventAggregator _eventAggregator;
        public static bool NeedRegistration = false;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var application = new App(new AndroidInitializer());
            _eventAggregator = application.Container.Resolve<IEventAggregator>();

            if(_eventAggregator != null)
            {
                _eventAggregator.GetEvent<NavigateToFacebookEvent>().Subscribe(OnNavigatingToFacebook);
            }
            
            LoadApplication(application);
            //Status bar color
            Window.SetStatusBarColor(Android.Graphics.Color.Rgb(153, 79, 148));
        }

        private void OnNavigatingToFacebook(bool obj)
        {
            NeedRegistration = obj;
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainer container)
        {
            
        }
    }


}

