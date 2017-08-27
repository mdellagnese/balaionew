using BalaioCulturalNew.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(BorderlessEntryEffect), "BorderlessEntryEffect")]

namespace BalaioCulturalNew.iOS.Effects
{
    public class BorderlessEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ((UITextField)Control).Layer.BorderWidth = 0;
            ((UITextField)Control).BorderStyle = UITextBorderStyle.None;
            ((UITextField)Control).AutocapitalizationType = UITextAutocapitalizationType.None;
        }

        protected override void OnDetached()
        {
        }
    }
}