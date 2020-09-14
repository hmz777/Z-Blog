using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Models
{
    public class IntersectionObserverEventArgs : EventArgs
    {
        public string boundingClientRect { get; set; }
        public string intersectionRatio { get; set; }
        public string intersectionRect { get; set; }
        public string isIntersecting { get; set; }
        public string rootBounds { get; set; }
        public string target { get; set; }
        public string time { get; set; }
    }
}
