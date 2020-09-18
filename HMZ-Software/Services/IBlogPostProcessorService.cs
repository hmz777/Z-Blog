using HMZSoftwareBlazorWebAssembly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMZSoftwareBlazorWebAssembly.Services;
using static HMZSoftwareBlazorWebAssembly.Models.BlogPostDocument;

namespace HMZSoftwareBlazorWebAssembly.Services
{
    public interface IBlogPostProcessorService
    {
        Task<BlogPostDocument> ProcessPostAsync(string Name);
        Task<YamlMetadata> ProcessPostMetadataAsync(string Name);
        Task<IEnumerable<YamlMetadata>> ProcessPostsMetadataAsync();
    }
}
