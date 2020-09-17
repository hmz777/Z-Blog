using Markdig;
using MarkupCompiler.Models;
using MarkupCompiler.Services;
using MarkupCompiler.Tools;
using System;
using System.IO;
using System.Linq;

namespace MarkupCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string Root = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", @"HMZ-Software\wwwroot\Blog"));

            Console.WriteLine("Cleaning up...");
            FileOps.CleanSite(Root);

            Console.WriteLine("Building the Markdig pipeline and compiling posts if they exist...");
            var PostDocuments = MarkupCompilerFactory.GetOrCreate().CompileMarkdown(Root);

            string MainSiteDataPath = Path.Combine(Root, "Site");

            Console.WriteLine("Creating the \"Site\" directory if it's not already created...");
            Directory.CreateDirectory(MainSiteDataPath);

            Console.WriteLine("Writing the compiled data to files in a form of .html and .yml...");
            foreach (var Document in PostDocuments)
            {
                using (StreamWriter markdownStreamWriter = File.CreateText(Path.Combine(MainSiteDataPath, Document.FileName) + ".html"))
                {
                    markdownStreamWriter.Write(Document.Markdown);
                }

                using (StreamWriter yamlStreamWriter1 = File.CreateText(Path.Combine(MainSiteDataPath, Document.FileName) + ".yml"))
                {
                    yamlStreamWriter1.Write(YamlTools.SerializeYaml(Document.Yaml));
                }
            }

            Console.WriteLine("Constructing blog metadata...");
            MetadataTool.ConstructMetadata(PostDocuments.Select(p => p.Yaml).ToList());
        }
    }
}
