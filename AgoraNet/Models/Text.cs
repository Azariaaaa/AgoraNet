using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoraNet.Core.Models
{
    public class Text : Element
    {
        public string Content { get; set; } = "";
        public string FontFamily { get; set; } = "Arial";
        public double FontSize { get; set; } = 16;

        public Text(double x, double y, double z, string content, string fillColor)
        : base(x, y, z)
        {
            Content = content;
            FillColor = fillColor;
        }

        public override string ToSvg()
        {
            return $"<text x=\"{X}\" y=\"{Y}\" z=\"{Z}\" fill=\"{FillColor}\" font-family=\"{FontFamily}\" font-size=\"{FontSize}\">{System.Security.SecurityElement.Escape(Content)}</text>";
        }
    }
}
