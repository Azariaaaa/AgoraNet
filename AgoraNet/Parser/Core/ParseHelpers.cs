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
        public static double ParseRequiredDouble(Dictionary<string, string> props, string key)
        {
            if (!props.TryGetValue(key, out var value))
                throw new ArgumentException($"Propriété '{key}' manquante.");

            if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                throw new ArgumentException($"Valeur invalide pour '{key}': '{value}'.");

            return result;
        }

        public static string ParseRequiredString(Dictionary<string, string> props, params string[] keys)
        {
            foreach (var key in keys)
            {
                if (props.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value))
                    return value;
            }
            throw new ArgumentException($"Propriété requise manquante ({string.Join("|", keys)}).");
        }

        public static string ParseFillColor(Dictionary<string, string> props)
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
