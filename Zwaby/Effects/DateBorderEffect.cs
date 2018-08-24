using System;
using Xamarin.Forms;

namespace Zwaby.Effects
{
    public class DateBorderEffect : RoutingEffect
    {
        public DateBorderEffect() : base("Zwaby.DateBorderEffect")
        {
        }

        // Optional attached properties

        public Color Color { get; set; }

        public float Width { get; set; }

        public float Radius { get; set; }
    }
}
