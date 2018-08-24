using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Zwaby.Effects;
using Zwaby.iOS.Effects;

[assembly: ExportEffect(typeof(DatePickerBorderEffect), "DateBorderEffect")]
namespace Zwaby.iOS.Effects
{
    public class DatePickerBorderEffect : PlatformEffect
    {
        public DatePickerBorderEffect()
        {
        }

        protected override void OnAttached()
        {
            DatePicker picker = Element as DatePicker;
            if (picker == null)
                return;

            try
            {
                var effect = (DateBorderEffect)Element.Effects.FirstOrDefault(e => e is DateBorderEffect);
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
