using HMZSoftwareBlazorWebAssembly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Helpers
{
    public static class HelperExtensions
    {
        public static List<string> ConstructTags(this List<YamlMetadata> yamlMetadata)
        {
            if (yamlMetadata.Count == 0)
                throw new Exception("Metadata is empty!");

            List<string> Tags = new List<string>();

            foreach (var post in yamlMetadata)
            {
                foreach (var tag in post.Tags)
                {
                    if (!Tags.Contains(tag))
                        Tags.Add(tag);
                }
            }

            return Tags;
        }
    }
}
