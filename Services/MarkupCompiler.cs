using Markdig;
using System;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Services
{
    public class MarkupCompiler : IMarkupCompilerService
    {
        public MarkdownPipeline MarkdownPipeline { get; set; }

        public Task<string> CompileMarkdown()
        {
            throw new NotImplementedException();
        }

        public Task<string> CompileRazor()
        {
            throw new NotImplementedException();
        }

        public Task<string> ParseYaml()
        {
            throw new NotImplementedException();
        }
    }
}
