using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgoraNet.Core.Models;

namespace AgoraNet.Core.Parser.Factories
{
    public class TextFactory : IElementFactory
    {
        public Element Create(Dictionary<string, string> properties)
        {
            double x = ParseRequiredDouble(properties, "x");
            double y = ParseRequiredDouble(properties, "y");
            double z = ParseRequiredDouble(properties, "z");

            string content = ParseRequiredString(properties, "content", "text");
            string fill = ParseFillColor(properties);

            Text text = new Text(x, y, z, content, fill);

            if (properties.ContainsKey("fontFamily"))
                text.FontFamily = properties["fontFamily"];

            if (properties.ContainsKey("fontSize"))
                text.FontSize = ParseRequiredDouble(properties, "fontSize");

            if (properties.ContainsKey("opacity"))
                text.Opacity = ParseRequiredDouble(properties, "opacity");

            return text;
        }

        private static double ParseRequiredDouble(IDictionary<string, string> props, string key)
        {
            if (!props.TryGetValue(key, out var value))
                throw new ArgumentException($"Property '{key}' missing.");

            if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                throw new ArgumentException($"Invalid value '{key}': '{value}'.");

            return result;
        }

        private static string ParseRequiredString(IDictionary<string, string> props, params string[] keys)
        {
            foreach (var key in keys)
            {
                if (props.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value))
                    return value;
            }
            throw new ArgumentException($"Required property missing ({string.Join("|", keys)}).");
        }

        private static string ParseFillColor(IDictionary<string, string> props)
        {
            if (props.TryGetValue("fillColor", out var c) && !string.IsNullOrWhiteSpace(c)) 
                return c;
            if (props.TryGetValue("fill", out c) && !string.IsNullOrWhiteSpace(c)) 
                return c;
            if (props.TryGetValue("color", out c) && !string.IsNullOrWhiteSpace(c)) 
                return c;

            return "#808080";
        }
    }
}
