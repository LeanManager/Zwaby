using System;
using Xamarin.Forms;

namespace Zwaby.Effects
{
    public class EditorOutlineEffect : RoutingEffect
    {
        public EditorOutlineEffect() : base("Zwaby.EditorOutlineEffect")
        {
        }

        // Optional attached properties

        public Color Color { get; set; }

        public float Width { get; set; }

        public float Radius { get; set; }
    }
}
