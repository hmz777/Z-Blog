using MarkupCompiler.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
