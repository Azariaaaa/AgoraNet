using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoraNet.Core.Models
{
    public class Square : Element
    {
        public double Size { get; set; }

        public Square(double x, double y, double z, double size, string fillColor)
            : base(x, y, z)
        {
            Size = size;
            FillColor = fillColor;
        }

        public override string ToSvg()
        {
            return $"<rect x=\"{X}\" y=\"{Y}\" width=\"{Size}\" height=\"{Size}\" " + $"fill=\"{FillColor}\" opacity=\"{Opacity}\" />";
        }
    }
}
