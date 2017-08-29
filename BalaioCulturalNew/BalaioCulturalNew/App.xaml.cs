using Prism.DryIoc;
using BalaioCulturalNew.Views;
using Xamarin.Forms;
using BalaioCulturalNew.Views.Login;
using BalaioCulturalNew.Views.Templates;
using BalaioCulturalNew.Views.Feed;
using Xamarin.Forms.Xaml;
using BalaioCulturalNew.ViewModels.Login;
using BalaioCulturalNew.ViewModels;
using BalaioCulturalNew.ViewModels.Templates;
using BalaioCulturalNew.ViewModels.Feed;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using BalaioCulturalNew.Views.MenuItems;
using BalaioCulturalNew.ViewModels.MenuItems;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BalaioCulturalNew
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            MobileCenter.Start("android=7f5c2202-81c7-490e-88fe-376eeb5dd442;" +
                   "ios=d6e2c014-7e50-480e-837d-82e0e423d4df;",
                   typeof(Analytics), typeof(Crashes));

            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            //Se não tiver usuario logado
            if (!Application.Current.Properties.ContainsKey("fb_access_token")) {
                NavigationService.NavigateAsync("app:///NavigationPage/LoginPage", null, true);
            }
            else
            {
                //Se já houver token
                NavigationService.NavigateAsync("app:///MainPage");
            }
            
        }

        protected override void RegisterTypes()
        {
            //Interfaces
            

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<LoginPage, LoginPageViewModel>();
            Container.RegisterTypeForNavigation<RegisterPage, RegisterPageViewModel>();
            Container.RegisterTypeForNavigation<EntryPage, EntryPageViewModel>();
            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<MainMenuPage, MainMenuPageViewModel>();
            Container.RegisterTypeForNavigation<MainDetailPage, MainDetailPageViewModel>();
            Container.RegisterTypeForNavigation<FeedPage, FeedPageViewModel>();
            Container.RegisterTypeForNavigation<FacebookLoginPage, FacebookLoginPageViewModel>();
            Container.RegisterTypeForNavigation<EventDetailPage, EventDetailPageViewModel>();
            Container.RegisterTypeForNavigation<MyProfilePage, MyProfilePageViewModel>();
        }

        public Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    //NavigationService.GoBackAsync();
                    NavigationService.NavigateAsync("app:///MainPage");
                });
            }
        }

        public Action GoBack
        {
            get
            {
                return new Action(() =>
                {
                    NavigationService.GoBackAsync();
                });
            }
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            if (!e.Observed)
            {
                //prevents the app domain from being torn down
                e.SetObserved();

                //show the crash page
                //TODO: Better exceptions handler
                this.NavigationService.NavigateAsync("app:///MainPage?error=true");
            }
        }
    }
}
