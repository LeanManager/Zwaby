using System;
using Xamarin.Forms;

namespace Zwaby.Effects
{
    public class ShadowEffect : RoutingEffect
    {
        public ShadowEffect() : base("Zwaby.ShadowEffect")
        {
        }

        public float Radius { get; set; }

        public Color Color { get; set; }

        public float DistanceX { get; set; }

        public float DistanceY { get; set; }
    }
}
