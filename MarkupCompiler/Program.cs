using Markdig;
using MarkupCompiler.Services;
using MarkupCompiler.Tools;
using System;

namespace MarkupCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //The blog root is expected to be the first argument
            string Root = args[0];


            //Build the Markdig pipeline
            var PipleLine = MarkupCompilerFactory.GetOrCreate();
        }
    }
}
