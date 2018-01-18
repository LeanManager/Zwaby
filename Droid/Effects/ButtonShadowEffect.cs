using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Zwaby.Droid.Effects;
using Zwaby.Effects;

[assembly: ResolutionGroupName("Zwaby")]
[assembly: ExportEffect(typeof(ButtonShadowEffect), "ShadowEffect")]
namespace Zwaby.Droid.Effects
{
    internal class ButtonShadowEffect : PlatformEffect
    {
        public ButtonShadowEffect()
        {
        }

        protected override void OnAttached()
        {
            // TODO: Shadow customization

            Button button = Element as Button;
            if (button == null)
                return;

            try
            {
                var control = Control as Android.Widget.Button;
                var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
                if (effect != null)
                {
                    float radius = effect.Radius;
                    float distanceX = effect.DistanceX;
                    float distanceY = effect.DistanceY;
                    //Android.Graphics.Color color = effect.Color.ToAndroid();
                    Android.Graphics.Color color = Android.Graphics.Color.Silver;
                    control.SetShadowLayer(radius, distanceX, distanceY, color);
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
