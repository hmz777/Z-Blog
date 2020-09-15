using HMZSoftwareBlazorWebAssembly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Services
{
    public interface IBlogPostProcessorService
    {
        Task<BlogPostDocument> ProcessPost(string Name);
    }
}
