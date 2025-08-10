using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoraNet.Core.Models
{
    public class Element
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string FillColor { get; set; } = "#808080";
        public double Opacity { get; set; }
    }
}
