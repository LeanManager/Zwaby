using System;
using Xamarin.Forms;

namespace Zwaby.Effects
{
    public class TimeBorderEffect : RoutingEffect
    {
        public TimeBorderEffect() : base("Zwaby.TimeBorderEffect")
        {
        }

        // Optional attached properties

        public Color Color { get; set; }

        public float Width { get; set; }

        public float Radius { get; set; }
    }
}
