using MarkupCompiler.Models;
using SimpleMvcSitemap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace MarkupCompiler.Tools
{
    public class MetadataTool
    {
        public static void ConstructMetadata(string path, IEnumerable<YamlMetadata> blogPostMetadata)
        {
            var JsonMetadata = JsonSerializer.Serialize(blogPostMetadata);

            File.WriteAllText(Path.Combine(path, "Metadata", "Metadata.json"), JsonMetadata);
        }
    }
}
