using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMZSoftwareBlazorWebAssembly.Models;
using HMZSoftwareBlazorWebAssembly.Services;

namespace HMZSoftwareBlazorWebAssembly.Shared
{
    public partial class BlogPosts : ComponentBase
    {
        [Inject] private IBlogPostProcessorService BlogPostProcessorService { get; set; }

        private bool IsDataLoading { get; set; } = true;
        private IEnumerable<BlogPostDocument> Posts { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Posts = await BlogPostProcessorService.ProcessPostsAsync();
        }
    }
}
