using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Zwaby.Effects;
using Zwaby.iOS.Effects;

[assembly: ExportEffect(typeof(EditorBorderEffect), "EditorOutlineEffect")]
namespace Zwaby.iOS.Effects
{
    public class EditorBorderEffect : PlatformEffect
    {
        public EditorBorderEffect()
        {
        }

        protected override void OnAttached()
        {
            Editor editor = Element as Editor;
            if (editor == null)
                return;

            try
            {
                var effect = (EditorOutlineEffect)Element.Effects.FirstOrDefault(e => e is EditorOutlineEffect);
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
