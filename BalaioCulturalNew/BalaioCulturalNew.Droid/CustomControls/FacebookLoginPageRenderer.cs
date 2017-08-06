﻿using Android.App;
using System;
using BalaioCulturalNew.Droid.CustomControls;
using BalaioCulturalNew.Views.Login;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Prism.DryIoc;
using Prism.Navigation;
using BalaioCulturalNew.ViewModels.Login;

[assembly: ExportRenderer(typeof(FacebookLoginPage), typeof(FacebookLoginPageRenderer))]

namespace BalaioCulturalNew.Droid.CustomControls
{
    public class FacebookLoginPageRenderer : PageRenderer
    {
        public FacebookLoginPageRenderer()
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                    clientId: "1834003460194581",
                    scope: "",
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
                );

            auth.Completed += (sender, eventArgs) => {
                // We presented the UI, so it's up to us to dimiss it on iOS.
                //DismissViewController(true, null);

                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    var userInfo = eventArgs.Account;

                    (App.Current as App).SuccessfulLoginAction.Invoke();
                }
                else
                {
                    // The user cancelled
                    (App.Current as App).Go.Invoke();
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
        
    }
}