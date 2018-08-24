using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Zwaby.Effects;
using Zwaby.iOS.Effects;

[assembly: ExportEffect(typeof(TimePickerBorderEffect), "TimeBorderEffect")]
namespace Zwaby.iOS.Effects
{
    public class TimePickerBorderEffect : PlatformEffect
    {
        public TimePickerBorderEffect()
        {
        }

        protected override void OnAttached()
        {
            TimePicker picker = Element as TimePicker;
            if (picker == null)
                return;

            try
            {
                var effect = (TimeBorderEffect)Element.Effects.FirstOrDefault(e => e is TimeBorderEffect);
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
