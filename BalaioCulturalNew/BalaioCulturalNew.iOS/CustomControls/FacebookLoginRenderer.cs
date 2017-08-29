using BalaioCulturalNew.iOS.CustomControls;
using BalaioCulturalNew.Models;
using BalaioCulturalNew.Views.Login;
using Newtonsoft.Json;
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

            auth.Completed += async (sender, eventArgs) => {
                // We presented the UI, so it's up to us to dimiss it on iOS.
                DismissViewController(true, null);

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
                            new Uri("https://graph.facebook.com/me?fields=email,picture.type(normal),name"),
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

                    if (AppDelegate.NeedRegistration == true)
                    {
                        //Get facebook Information
                        Console.WriteLine("Entered");
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
                        (App.Current as App).SuccessfulLoginAction.Invoke();
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
            };
            done = true;
            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
