using HMZSoftwareBlazorWebAssembly.Models;
using HMZSoftwareBlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Shared
{
    public partial class BlogPosts : ComponentBase
    {
        [Inject] private IBlogPostProcessorService BlogPostProcessorService { get; set; }

        private bool IsDataLoading { get; set; } = true;
        private IEnumerable<YamlMetadata> PostsMetadata { get; set; }

        protected async override Task OnInitializedAsync()
        {
            PostsMetadata = await BlogPostProcessorService.ProcessPostsMetadataAsync();
        }
    }
}
