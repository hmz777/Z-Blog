using HMZSoftwareBlazorWebAssembly.Models;
using System.Collections.Generic;

namespace HMZSoftwareBlazorWebAssembly.Helpers
{
    public class GlobalVariables
    {
        public static List<YamlMetadata> YamlMetadata { get; set; }
        public static List<GitRepo> GitHubData { get; set; }
    }
}
