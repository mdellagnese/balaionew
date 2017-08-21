using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using DryIoc;
using Prism.DryIoc;
using BalaioCulturalNew.ViewModels.Login;
using Prism.Events;
using FFImageLoading.Forms.Touch;

namespace BalaioCulturalNew.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        protected IEventAggregator _eventAggregator;
        public static bool NeedRegistration = false;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            CachedImageRenderer.Init();

            var application = new App(new iOSInitializer());
            _eventAggregator = application.Container.Resolve<IEventAggregator>();

            if (_eventAggregator != null)
            {
                _eventAggregator.GetEvent<NavigateToFacebookEvent>().Subscribe(OnNavigatingToFacebook);
            }
            
            LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }

        private void OnNavigatingToFacebook(bool obj)
        {
            NeedRegistration = obj;
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainer container)
        {

        }
    }

}
