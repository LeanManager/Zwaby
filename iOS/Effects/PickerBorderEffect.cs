﻿using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Zwaby.Effects;
using Zwaby.iOS.Effects;

[assembly: ExportEffect(typeof(PickerBorderEffect), "OutlineEffect")]
namespace Zwaby.iOS.Effects
{
    public class PickerBorderEffect : PlatformEffect
    {
        public PickerBorderEffect()
        {
        }

        protected override void OnAttached()
        {
            Picker picker = Element as Picker;
            if (picker == null)
                return;

            try
            {
                var effect = (OutlineEffect)Element.Effects.FirstOrDefault(e => e is OutlineEffect);
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
