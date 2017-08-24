using Xamarin.Forms;

namespace BalaioCulturalNew.Views.Feed
{
    public partial class FeedPage : ContentPage
    {
        public FeedPage()
        {
            InitializeComponent();

            feedList.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }
    }
}
