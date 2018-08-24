using System;
using Xamarin.Forms;

namespace Zwaby.Effects
{
    public class BorderEffect : RoutingEffect
    {
        public BorderEffect() : base("Zwaby.BorderEffect")
        {
        }

        // Optional attached properties

        public Color Color { get; set; }

        public float Width { get; set; }

        public float Radius { get; set; }
    }
}
