using BalaioCulturalNew.iOS.CustomControls;
using BalaioCulturalNew.Views.Login;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FacebookLoginPage), typeof(FacebookLoginRenderer))]

namespace BalaioCulturalNew.iOS.CustomControls
{

    public class FacebookLoginRenderer : PageRenderer
    {
        bool done = false;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (done)
                return;

            var auth = new OAuth2Authenticator(
                    clientId: "1834003460194581",
                    scope: "public_profile+email",
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
                );

            auth.Completed += (sender, eventArgs) => {
                // We presented the UI, so it's up to us to dimiss it on iOS.
                DismissViewController(true, null);

                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    var userInfo = eventArgs.Account;
                    var accessToken = userInfo.Properties["access_token"];

                    if (AppDelegate.NeedRegistration == true)
                    {
                        //Get facebook Information
                        Console.WriteLine("Entered");
                    }

                    App.Current.Properties["fb_access_token"] = accessToken;

                    //Navigate
                    (App.Current as App).SuccessfulLoginAction.Invoke();
                }
                else
                {
                    // The user cancelled
                    (App.Current as App).GoBack.Invoke();
                }
            };
            done = true;
            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
