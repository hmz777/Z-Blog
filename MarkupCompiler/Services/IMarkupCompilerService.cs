using MarkupCompiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkupCompiler.Services
{
    public interface IMarkupCompilerService
    {
        IEnumerable<BlogPostDocument> CompileMarkdown(string Root);
    }
}
