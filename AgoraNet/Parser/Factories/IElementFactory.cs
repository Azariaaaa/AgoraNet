using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgoraNet.Core.Models;

namespace AgoraNet.Core.Parser.Factories
{
    public interface IElementFactory
    {
        Element Create(Dictionary<string, string> properties);
    }
}
