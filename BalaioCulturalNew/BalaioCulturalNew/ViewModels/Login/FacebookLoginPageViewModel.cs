using BalaioCulturalNew.Events;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;

namespace BalaioCulturalNew.ViewModels.Login
{
    public class FacebookLoginPageViewModel : BaseViewModel
    {
        public bool NeedRegistration { get; set; }

        public FacebookLoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IEventAggregator eventAggregator) : base(navigationService, pageDialogService, eventAggregator)
        {
            NeedRegistration = true;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("NeedRegistration"))
            {
                NeedRegistration = (bool)parameters["NeedRegistration"];
                _eventAggregator.GetEvent<NavigateToFacebookEvent>().Publish(true);
            }    
        }

    }
}
