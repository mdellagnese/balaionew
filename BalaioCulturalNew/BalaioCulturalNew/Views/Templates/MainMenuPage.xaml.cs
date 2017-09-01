using Xamarin.Forms;

namespace BalaioCulturalNew.Views.Templates
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();

            listMenu.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };
        }
        
    }
}
