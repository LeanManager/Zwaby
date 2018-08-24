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

            //Button button = Element as Button;
            if (Element == null)
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
                    Android.Graphics.Color color = effect.Color.ToAndroid();
                    //Android.Graphics.Color color = Android.Graphics.Color.LightSlateGray;
                    control.SetShadowLayer(radius, distanceX, distanceY, color);
                    //control.SetHintTextColor(Android.Graphics.Color.Black);

                    // TODO: Set TranslationZ and Elevation

                    //control.StateListAnimator = new Android.Animation.StateListAnimator();
                    //Control.Elevation = 12.0f;
                    //Control.TranslationZ = 14.0f;
                    //Control.SetBackgroundResource(Resource.Layout.shadow);
                    //Control.SetBackgroundColor(color);
                    //control.TranslationZ = 14;);
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
