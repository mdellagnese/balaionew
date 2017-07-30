using DryIoc;
using Prism.DryIoc;
using BalaioCulturalNew.Views;
using Xamarin.Forms;
using BalaioCulturalNew.Views.Login;

namespace BalaioCulturalNew
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<RegisterPage>();
            Container.RegisterTypeForNavigation<EntryPage>();
        }
    }
}
