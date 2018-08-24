using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Zwaby.Droid.Effects;
using Zwaby.Effects;

[assembly: ExportEffect(typeof(EntryBorderEffect), "BorderEffect")]
namespace Zwaby.Droid.Effects
{
    public class EntryBorderEffect : PlatformEffect
    {
        public EntryBorderEffect()
        {
        }

        protected override void OnAttached()
        {
            Entry entry = Element as Entry;
            if (entry == null)
                return;

            try
            {
                var control = Control as Android.Widget.EditText;

                var effect = (BorderEffect)Element.Effects.FirstOrDefault(e => e is BorderEffect);
                if (effect != null)
                {
                    float width = effect.Width;
                    float radius = effect.Radius;
                    Android.Graphics.Color color = effect.Color.ToAndroid();

                    // Customization
                    //control.SetBackgroundResource(Resource.Layout.EditTextLayout);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}
