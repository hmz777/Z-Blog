using MarkupCompiler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarkupCompiler.Tools
{
    public class MetadataTool
    {
        public static void ConstructMetadata(IEnumerable<YamlMetadata> blogPostMetadata)
        {
            string FilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\HMZ-Software\wwwroot\Blog\Metadata\Metadata.json"));

            var JsonMetadata = JsonSerializer.Serialize(blogPostMetadata);

            File.WriteAllText(FilePath, JsonMetadata);
        }
    }
}
