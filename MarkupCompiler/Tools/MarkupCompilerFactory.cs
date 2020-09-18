using Markdig;
using MarkupCompiler.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkupCompiler.Tools
{
    public class MarkupCompilerFactory
    {
        private static IMarkupCompilerService MarkupCompilerWorker { get; set; }

        public static IMarkupCompilerService GetOrCreate()
        {
            if (MarkupCompilerWorker != null)
                return MarkupCompilerWorker;

            var Pipeline = new MarkdownPipelineBuilder()
                .UseYamlFrontMatter()
                .UseEmojiAndSmiley()
                .UseSmartyPants()
                .UseAdvancedExtensions()
                .Build();

            MarkupCompilerWorker = new MarkupCompilerWorker(Pipeline);

            return MarkupCompilerWorker;
        }
    }
}
