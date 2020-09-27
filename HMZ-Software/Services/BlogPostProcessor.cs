using HMZSoftwareBlazorWebAssembly.Helpers;
using HMZSoftwareBlazorWebAssembly.Models;
using HMZSoftwareBlazorWebAssembly.Tools;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace HMZSoftwareBlazorWebAssembly.Services
{
    public class BlogPostProcessor : IBlogPostProcessorService
    {
        public BlogPostProcessor(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task<BlogPostDocument> ProcessPostAsync(string Name)
        {
            return new BlogPostDocument()
            {
                Html = await HttpClient.GetStringAsync($"/Blog/Site/{Name}.html"),
                Yaml = YamlTools
                .DeserializeYaml(await HttpClient.GetStringAsync($"Blog/Site/{Name}.yml"))
            };
        }

        public async Task<YamlMetadata> ProcessPostMetadataAsync(string Name)
        {
            return YamlTools
                .DeserializeYaml(await HttpClient.GetStringAsync($"/Blog/Site/{Name}.yml"));
        }

        public async Task<List<YamlMetadata>> ProcessPostsMetadataAsync()
        {
            //Cache the metadata json file
            if (GlobalVariables.YamlMetadata == null)
                GlobalVariables.YamlMetadata = await HttpClient
                    .GetFromJsonAsync<List<YamlMetadata>>($"/Blog/Metadata/Metadata.json");

            return GlobalVariables.YamlMetadata;
        }

        public async Task<List<string>> ProcessTagsAsync()
        {
            if (GlobalVariables.Tags == null)
                GlobalVariables.Tags = (await ProcessPostsMetadataAsync()).ConstructTags();

            return GlobalVariables.Tags;
        }
    }
}
