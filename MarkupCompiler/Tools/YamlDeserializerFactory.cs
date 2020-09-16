using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace MarkupCompiler.Tools
{
    public class YamlDeserializerFactory
    {
        private static IDeserializer Deserializer { get; set; }

        public static IDeserializer GetOrCreate()
        {
            if (Deserializer != null)
                return Deserializer;

            Deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            return Deserializer;
        }
    }
}
