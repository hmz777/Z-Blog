using HMZSoftwareBlazorWebAssembly.Models;
using HMZSoftwareBlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Shared
{
    public partial class BlogPosts : ComponentBase
    {
        [Inject] private IBlogPostProcessorService BlogPostProcessorService { get; set; }

        private bool IsDataLoading { get; set; } = true;
        private bool DataIsEmpty { get; set; } = true;
        private IEnumerable<YamlMetadata> PostsMetadata { get; set; }

        protected async override Task OnInitializedAsync()
        {
            PostsMetadata = await BlogPostProcessorService.ProcessPostsMetadataAsync();

            if (PostsMetadata != null && PostsMetadata.Count() != 0)
                DataIsEmpty = false;

            IsDataLoading = false;
        }
    }
}
