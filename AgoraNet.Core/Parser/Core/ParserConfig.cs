using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgoraNet.Core.Parser.Factories;

namespace AgoraNet.Core.Parser.Core
{
    public static class ParserConfig
    {
        private static bool _initialized = false;

        public static void RegisterDefaults()
        {
            if (_initialized) 
                return;

            ElementsRegistry.Register("Square", new SquareFactory());
            ElementsRegistry.Register("Text", new TextFactory());

            _initialized = true;
        }
    }
}
