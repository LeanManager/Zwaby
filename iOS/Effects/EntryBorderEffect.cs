using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Zwaby.Effects;
using Zwaby.iOS.Effects;

[assembly: ExportEffect(typeof(EntryBorderEffect), "BorderEffect")]
namespace Zwaby.iOS.Effects
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
                var effect = (BorderEffect)Element.Effects.FirstOrDefault(e => e is BorderEffect);
                if (effect != null)
                {
                    Control.Layer.BorderColor = effect.Color.ToCGColor();
                    Control.Layer.BorderWidth = effect.Width;
                    Control.Layer.CornerRadius = effect.Radius;
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
