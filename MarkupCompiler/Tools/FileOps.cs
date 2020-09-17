using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarkupCompiler.Tools
{
    public class FileOps
    {
        public static void CleanSite(string path)
        {
            //Cleans The targeted folder from files and folders
            foreach (var item in Directory.EnumerateDirectories(Path.Combine(path, "Metadata")))
            {
                Directory.Delete(item);
            }

            foreach (var item in Directory.EnumerateFiles(Path.Combine(path, "Metadata")))
            {
                File.Delete(item);
            }

            foreach (var item in Directory.EnumerateDirectories(Path.Combine(path, "Site")))
            {
                Directory.Delete(item);
            }

            foreach (var item in Directory.EnumerateFiles(Path.Combine(path, "Site"), "*.html"))
            {
                File.Delete(item);
            }

            foreach (var item in Directory.EnumerateFiles(Path.Combine(path, "Site"), "*.yml"))
            {
                File.Delete(item);
            }
        }
    }
}
