using Android.Graphics;
using Android.Widget;
using ControlExplorer.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(MyCustomFontEffect), "CustomFontEffect")]

namespace ControlExplorer.Droid.Effects
{
    public class MyCustomFontEffect : PlatformEffect
    {
        Typeface oldFont;

        protected override void OnAttached()
        {
            if (Element is Label == false)
                return;

            var label = Control as TextView; 

            oldFont = label.Typeface;

            var font = Typeface.CreateFromAsset(Forms.Context.Assets, "Pacifico.ttf"); 
            label.Typeface = font;
        }

        protected override void OnDetached()
        {
            if (oldFont != null)
            {
                var label = Control as TextView;

                label.Typeface = oldFont;
            }
        }
    }
}