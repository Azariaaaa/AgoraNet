using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoraNet.Core.Models
{
    public abstract class Element
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double Z { get; set; } = 1;
        public string FillColor { get; set; } = "#808080";
        public double Opacity { get; set; } = 1;

        public Element(double x, double y, double z, string fillColor, double opacity)
        {
            X = x;
            Y = y;
            Z = z;
            FillColor = fillColor;
            Opacity = opacity;
        }

        public abstract string ToSvg();
    }
}
