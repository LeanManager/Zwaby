using System;
using System.Linq;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Zwaby.Effects;
using Zwaby.iOS.Effects;

[assembly: ResolutionGroupName("Zwaby")]
[assembly: ExportEffect(typeof(ButtonShadowEffect), "ShadowEffect")]
namespace Zwaby.iOS.Effects
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
                var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
                if (effect != null)
                {
                    Control.Layer.CornerRadius = effect.Radius;
                    //Control.Layer.ShadowColor = effect.Color.ToCGColor();
                    Control.Layer.ShadowColor = Color.FromRgb(45, 45, 45).ToCGColor();
                    Control.Layer.ShadowOffset = new CGSize(effect.DistanceX, effect.DistanceY);
                    Control.Layer.ShadowOpacity = 1.0f;
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
