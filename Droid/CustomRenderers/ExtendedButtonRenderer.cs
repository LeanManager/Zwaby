using System;
using Android.Content;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Zwaby.CustomControls;
using Zwaby.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]
namespace Zwaby.Droid.CustomRenderers
{
    public class ExtendedButtonRenderer : ButtonRenderer
    {
        public ExtendedButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            //if (Control == null)
            //{
            Control.Background.SetColorFilter(Xamarin.Forms.Color.Black.ToAndroid(), PorterDuff.Mode.SrcAtop);
            //Control.SetShadowLayer(Element.CornerRadius, 15, 15, Android.Graphics.Color.Black);
            Control.Elevation = 18.0f;
            Control.TranslationZ = 20.0f;
            Control.SetBackgroundResource(Resource.Layout.shadow);
                //Control.Elevation = 14.0f;
            //}
        }
    }
}
