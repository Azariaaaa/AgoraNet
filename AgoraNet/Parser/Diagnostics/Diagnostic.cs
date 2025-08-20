using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoraNet.Core.Parser.Diagnostics
{
    public class Diagnostic
    {
        public TimeSpan BuildDuration { get; set; }
        public long PageSizeBytes { get; set; }
    }
}
