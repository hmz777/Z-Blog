using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Renderers;
using Markdig.Syntax;
using MarkupCompiler.Models;
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
            //Grab Markdown files
            var Paths = Directory.GetFiles(Root, "*.md");
            if (Paths.Length == 0)
            {
                File.AppendAllText("Compiler.log", $"No posts found in {Root}!{Environment.NewLine}");

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

                    var YamlData = ParseYaml(yaml);

                    htmlRenderer.Render(Document);
                    stringWriter.Flush();

                    Docs.Add(new BlogPostDocument { Yaml = YamlData, Markdown = stringWriter.ToString() });
                }
            }

            return Docs;
        }

        public YamlMetadata ParseYaml(string yaml)
        {
            throw new NotImplementedException();
        }
    }
}
