using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Services
{
    public interface IMarkupCompilerService
    {
        Task<string> CompileRazor();
        Task<string> CompileMarkdown();
        Task<string> ParseYaml();
    }
}
