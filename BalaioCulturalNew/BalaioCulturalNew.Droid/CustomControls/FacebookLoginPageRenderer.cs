using Android.App;
using System;
using BalaioCulturalNew.Droid.CustomControls;
using BalaioCulturalNew.Views.Login;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BalaioCulturalNew.Models;

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
                    scope: "public_profile,email,user_location",
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
                );

            auth.Completed += FacebookLoginasync;

            activity.StartActivity(auth.GetUI(activity));
        }

        private async void FacebookLoginasync(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            
            // We presented the UI, so it's up to us to dimiss it on iOS.
            //DismissViewController(true, null);

            if (eventArgs.IsAuthenticated)
            {
                // Use eventArgs.Account to do wonderful things
                var userAccount = eventArgs.Account;
                var accessToken = userAccount.Properties["access_token"];

                try
                {
                    //Get facebook Information
                    var graphRequest = new OAuth2Request(
                        "GET",
                        new Uri("https://graph.facebook.com/me?fields=email,picture.type(large),name"),
                        null,
                        userAccount
                    );

                    var response = await graphRequest.GetResponseAsync();
                    var userData = JsonConvert.DeserializeObject<User>(response.GetResponseText()) as User;

                    //Save the Users details
                    App.Current.Properties["profile_image_url"] = userData.picture.data.url;
                    App.Current.Properties["email"] = userData.email;
                    App.Current.Properties["user_full_name"] = userData.name;
                    
                }
                catch (Exception e)
                {
                    throw e;
                }

                if (MainActivity.NeedRegistration == true)
                {
                    //Post new register to API
                }
                else
                {
                    //Gets Balio APi Token
                }

                //Save the API Token - We need a new request to Balio API to get the token
                App.Current.Properties["fb_access_token"] = accessToken;

                //Navigate
                try
                {
                    (App.Current as App).SuccessfulLoginAction();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                // The user cancelled
                (App.Current as App).GoBack.Invoke();
            }
            
        }
    }
}