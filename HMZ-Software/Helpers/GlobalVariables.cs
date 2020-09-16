using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Helpers
{
    public class GlobalVariables
    {
        public static string RootPath => Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
    }
}
