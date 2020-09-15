using HMZSoftwareBlazorWebAssembly.Services;
using Markdig;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IMarkupCompilerService>(sp => new MarkupCompiler() { MarkdownPipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseYamlFrontMatter()
                .UseEmojiAndSmiley()
                .UseSmartyPants()
                .Build() 
            });
            builder.Services.AddSingleton<IBlogPostProcessorService>(sp => new BlogPostProcessor());

            await builder.Build().RunAsync();
        }
    }
}

