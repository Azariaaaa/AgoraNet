using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgoraNet.Core.Models;
using AgoraNet.Core.Parser.Core;

namespace AgoraNet.Core.Parser.Factories
{
    public class TextFactory : IElementFactory
    {
        public Element Create(Dictionary<string, string> properties)
        {
            double x = ParseHelpers.ParseRequiredDouble(properties, "x");
            double y = ParseHelpers.ParseRequiredDouble(properties, "y");
            double z = ParseHelpers.ParseRequiredDouble(properties, "z");
            string content = ParseHelpers.ParseRequiredString(properties, "content", "text");
            string fillColor = ParseHelpers.ParseFillColor(properties);
            double opacity = ParseHelpers.ParseRequiredDouble(properties, "opacity");
            string fontFamilly = ParseHelpers.ParseRequiredString(properties, "fontFamilly", "text");
            double fontSize = ParseHelpers.ParseRequiredDouble(properties, "fontSize");

            Text text = new Text(x, y, z, content, fillColor, opacity, fontFamilly, fontSize);

            if (properties.ContainsKey("fontFamily"))
                text.FontFamily = properties["fontFamily"];

            if (properties.ContainsKey("fontSize"))
                text.FontSize = ParseHelpers.ParseRequiredDouble(properties, "fontSize");

            if (properties.ContainsKey("opacity"))
                text.Opacity = ParseHelpers.ParseRequiredDouble(properties, "opacity");

            return text;
        }
    }
}
