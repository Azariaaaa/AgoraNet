using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgoraNet.Core.Models;

namespace AgoraNet.Core.Parser.Diagnostics
{
    public class ParseResult
    {
        public bool Success { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
        public Diagnostic Diagnostic { get; set; } = new Diagnostic();
    }
}