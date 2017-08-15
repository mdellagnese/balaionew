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

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BalaioCulturalNew
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            //Se não tiver usuario logado
            if (!Properties.ContainsKey("fb_access_token")) {
                NavigationService.NavigateAsync("app:///NavigationPage/LoginPage", null, true);
            }
            else
            {
                //Se já houver token
                NavigationService.NavigateAsync("app:///MainPage");
            }
            
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            if(!e.Observed)
            {
                //prevents the app domain from being torn down
                e.SetObserved();

                //show the crash page
                //TODO: Better exceptions handler
                this.NavigationService.NavigateAsync("app:///MainPage?error=true");
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
            Container.RegisterTypeForNavigation<EventDetailPage>();
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
    }
}
