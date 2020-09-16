using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Renderers;
using Markdig.Syntax;
using MarkupCompiler.Models;
using MarkupCompiler.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkupCompiler.Services
{
    public class MarkupCompilerWorker : IMarkupCompilerService
    {
        private MarkdownPipeline MarkdownPipeline { get; set; }

        public MarkupCompilerWorker(MarkdownPipeline markdownPipeline)
        {
            this.MarkdownPipeline = markdownPipeline;
        }

        public IEnumerable<BlogPostDocument> CompileMarkdown(string Root)
        {
            var PostDirectory = Path.Combine(Root, "Posts");

            //Grab Markdown files
            var Paths = Directory.GetFiles(PostDirectory, "*.md");
            if (Paths.Length == 0)
            {
                File.AppendAllText("Compiler.log", $"No posts found in {PostDirectory}!{Environment.NewLine}");

                return default;
            }

            List<BlogPostDocument> Docs = new List<BlogPostDocument>();

            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlRenderer htmlRenderer = new HtmlRenderer(stringWriter);
                MarkdownPipeline.Setup(htmlRenderer);

                foreach (var Path in Paths)
                {
                    var markdown = File.ReadAllText(Path);

                    MarkdownDocument Document = Markdown.Parse(markdown, MarkdownPipeline);

                    //Get yaml metadata
                    var yamlBlock = Document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

                    if (yamlBlock == null)
                    {
                        File.AppendAllText("Compiler.log", $"File with path {Path} has no Yaml metadata!{Environment.NewLine}");
                        continue;
                    }

                    string yaml = markdown.Substring(yamlBlock.Span.Start, yamlBlock.Span.Length);

                    htmlRenderer.Render(Document);
                    stringWriter.Flush();

                    Docs.Add(new BlogPostDocument { Yaml = yaml, Markdown = stringWriter.ToString(), FileName = Path.Substring(Path.LastIndexOf('\\')).Remove(Path.LastIndexOf('.')) });
                }
            }

            return Docs;
        }

        public YamlMetadata ParseYaml(string yaml)
        {
            var yamlDeserializer = YamlDeserializerFactory.GetOrCreate();

            return yamlDeserializer.Deserialize<YamlMetadata>(yaml);
        }
    }
}
