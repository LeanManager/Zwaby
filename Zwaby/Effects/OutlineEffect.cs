using System;
using Xamarin.Forms;

namespace Zwaby.Effects
{
    public class OutlineEffect : RoutingEffect
    {
        public OutlineEffect() : base("Zwaby.OutlineEffect")
        {
        }

        // Optional attached properties

        public Color Color { get; set; }

        public float Width { get; set; }

        public float Radius { get; set; }
    }
}
