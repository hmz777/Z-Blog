using Markdig;
using MarkupCompiler.Models;
using MarkupCompiler.Services;
using MarkupCompiler.Tools;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MarkupCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string Root = Path.GetFullPath(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, @"..\..\..\..\", @"HMZ-Software\wwwroot\Blog"));

                Console.WriteLine("Cleaning up...");
                FileOps.CleanSite(Root);

                Console.WriteLine("Building the Markdig pipeline and compiling posts if they exist...");
                var PostDocuments = MarkupCompilerFactory.GetOrCreate().CompileMarkdown(Root);

                string MainSiteDataPath = Path.Combine(Root, "Site");

                Console.WriteLine("Creating the necessary directories if they're not already created...");
                Directory.CreateDirectory(Path.Combine(MainSiteDataPath, "Metadata"));
                Directory.CreateDirectory(Path.Combine(MainSiteDataPath, "Site"));

                Console.WriteLine("Writing the compiled data to files in a form of .html and .yml...");
                foreach (var Document in PostDocuments)
                {
                    using (StreamWriter markdownStreamWriter = File.CreateText(Path.Combine(MainSiteDataPath, Document.Yaml.FileName) + ".html"))
                    {
                        markdownStreamWriter.Write(Document.Markdown);
                    }

                    using (StreamWriter yamlStreamWriter1 = File.CreateText(Path.Combine(MainSiteDataPath, Document.Yaml.FileName) + ".yml"))
                    {
                        yamlStreamWriter1.Write(YamlTools.SerializeYaml(Document.Yaml));
                    }
                }

                Console.WriteLine("Constructing blog metadata...");
                MetadataTool.ConstructMetadata(Root, PostDocuments.Select(p => p.Yaml).ToList());
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "ExecuteLog.log"), $"{Environment.NewLine}{ex.Message}");
            }
        }
    }
}
