using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Models
{
    public class IntersectionObserverEventArgs
    {
        public bool isIntersecting { get; set; }
        public string elementId { get; set; }
    }

    public class Target
    {
        public string id { get; set; }
        public string nodeName { get; set; }
    }

    public class DOMRect
    {
        public double top { get; set; }
        public double bottom { get; set; }
        public double left { get; set; }
        public double right { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }
}
