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
        Task<IEnumerable<BlogPostDocument>> ProcessPostsAsync();
        Task<BlogPostDocument> ProcessPostAsync(string Name);
        Task<IEnumerable<YamlMetadata>> ProcessPostsMetadataAsync();
        Task<YamlMetadata> ProcessPostMetadataAsync(string Name);
    }
}
