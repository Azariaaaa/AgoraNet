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
    public class SquareFactory : IElementFactory
    {
        public Element Create(Dictionary<string, string> properties)
        {
            double x = ParseHelpers.ParseRequiredDouble(properties, "x");
            double y = ParseHelpers.ParseRequiredDouble(properties, "y");
            double z = ParseHelpers.ParseRequiredDouble(properties, "z");
            double size = ParseHelpers.ParseRequiredDouble(properties, "size");

            string fill = ParseHelpers.ParseFillColor(properties);

            var square = new Square(x, y, z, size, fill);

            if (properties.ContainsKey("opacity"))
                square.Opacity = ParseHelpers.ParseRequiredDouble(properties, "opacity");

            return square;
        }
    }
}
