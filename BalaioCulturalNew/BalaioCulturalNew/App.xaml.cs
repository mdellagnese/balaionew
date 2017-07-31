using Prism.DryIoc;
using BalaioCulturalNew.Views;
using Xamarin.Forms;
using BalaioCulturalNew.Views.Login;
using BalaioCulturalNew.Views.Templates;
using BalaioCulturalNew.Views.Feed;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BalaioCulturalNew
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            //NavigationService.NavigateAsync("NavigationPage/LoginPage");
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<RegisterPage>();
            Container.RegisterTypeForNavigation<EntryPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MainMenuPage>();
            Container.RegisterTypeForNavigation<MainDetailPage>();
            Container.RegisterTypeForNavigation<FeedPage>();
        }
    }
}
