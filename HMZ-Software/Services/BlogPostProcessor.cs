using HMZSoftwareBlazorWebAssembly.Models;
using HMZSoftwareBlazorWebAssembly.Tools;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Services
{
    public class BlogPostProcessor : IBlogPostProcessorService
    {
        [Inject] private HttpClient HttpClient { get; set; }

        public async Task<BlogPostDocument> ProcessPostAsync(string Name)
        {
            return new BlogPostDocument()
            {
                Html = await HttpClient.GetStringAsync($"Blog/{Name}.html"),
                Yaml = YamlDeserializerFactory.GetOrCreate()
                .Deserialize<YamlMetadata>(await HttpClient.GetStringAsync($"Blog/{Name}.yml"))
            };
        }

        public Task<YamlMetadata> ProcessPostMetadataAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlogPostDocument>> ProcessPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<YamlMetadata>> ProcessPostsMetadataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
