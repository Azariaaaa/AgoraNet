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

        public Text(double x, double y, double z, string content, string fillColor, double opacity, string fontFamilly, double fontSize)
            : base(x, y, z, fillColor, opacity)
        {
            Content = content;
            FontFamily = fontFamilly;
            FontSize = fontSize;
        }

        public override string ToSvg()
        {
            return $"<text x=\"{X}\" y=\"{Y}\" z=\"{Z}\" fill=\"{FillColor}\" font-family=\"{FontFamily}\" font-size=\"{FontSize}\">{System.Security.SecurityElement.Escape(Content)}</text>";
        }
    }
}
