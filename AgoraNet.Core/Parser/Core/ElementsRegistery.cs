using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgoraNet.Core.Models;
using AgoraNet.Core.Parser.Factories;

namespace AgoraNet.Core.Parser.Core
{
    public static class ElementsRegistry
    {
        private static readonly Dictionary<string, IElementFactory> _map =
            new Dictionary<string, IElementFactory>(StringComparer.OrdinalIgnoreCase);

        public static void Register(string typeKey, IElementFactory factory)
        {
            _map[typeKey] = factory;
        }

        public static Element Create(string typeKey, Dictionary<string, string> props)
        {
            if (!_map.ContainsKey(typeKey))
                throw new NotSupportedException("Type '" + typeKey + "' not supported.");

            return _map[typeKey].Create(props);
        }

        public static Element TryCreate(string typeKey, Dictionary<string, string> props)
        {
            if (!_map.ContainsKey(typeKey))
                return null;

            try
            {
                return _map[typeKey].Create(props);
            }
            catch
            {
                return null;
            }
        }
    }
}
