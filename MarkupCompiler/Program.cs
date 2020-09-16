using Markdig;
using MarkupCompiler.Services;
using MarkupCompiler.Tools;
using System;
using System.IO;

namespace MarkupCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //The blog root is expected to be the first argument
            string Root = args[0];

            //Build the Markdig pipeline and compile posts if they exist
            var PostDocuments = MarkupCompilerFactory.GetOrCreate().CompileMarkdown(Root);

            string MainSiteDataPath = Path.Combine(Root, "Site");
            Directory.CreateDirectory(MainSiteDataPath);

            foreach (var Document in PostDocuments)
            {
                using (StreamWriter markdownStreamWriter = File.CreateText(Path.Combine(MainSiteDataPath, Document.FileName) + ".html"))
                {
                    markdownStreamWriter.Write(Document.Markdown);
                }

                using (StreamWriter yamlStreamWriter1 = File.CreateText(Path.Combine(MainSiteDataPath, Document.FileName) + ".yml"))
                {
                    yamlStreamWriter1.Write(Document.Yaml);
                }
            }
        }
    }
}
