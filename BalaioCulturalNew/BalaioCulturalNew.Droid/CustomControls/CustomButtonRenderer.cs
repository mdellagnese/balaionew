using BalaioCulturalNew.CustomControls;
using BalaioCulturalNew.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer( typeof(CustomButton), typeof(CustomButtonRenderer))]

namespace BalaioCulturalNew.Droid.CustomControls
{
    class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
        }
    }
}