using BalaioCulturalNew.iOS.CustomControls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FacebookLoginRenderer), typeof(FacebookLoginRenderer))]

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
                    scope: "",
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
                    //Create facebook file
                    AccountStore.Create().Save(eventArgs.Account, "Facebook");
                    //Navigate
                    (App.Current as App).SuccessfulLoginAction.Invoke();
                }
                else
                {
                    // The user cancelled
                    (App.Current as App).GoBack.Invoke();
                }
            };

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
