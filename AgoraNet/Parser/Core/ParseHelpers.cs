using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoraNet.Core.Parser.Core
{
    public static class ParseHelpers
    {
        public static double ParseRequiredDouble(Dictionary<string, string> properties, string key)
        {
            if (!properties.TryGetValue(key, out var value))
                throw new ArgumentException($"Property '{key}' missing.");

            if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                throw new ArgumentException($"Invalid value '{key}': '{value}'.");

            return result;
        }

        public static string ParseRequiredString(Dictionary<string, string> properties, params string[] keys)
        {
            foreach (string key in keys)
            {
                if (properties.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value))
                    return value;
            }
            throw new ArgumentException($"Required property missing ({string.Join("|", keys)}).");
        }

        public static string ParseFillColor(Dictionary<string, string> properties)
        {
            if (properties.TryGetValue("fillColor", out var c) && !string.IsNullOrWhiteSpace(c)) 
                return c;

            return "#808080";
        }

        public static int GetPropertyIndex(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
