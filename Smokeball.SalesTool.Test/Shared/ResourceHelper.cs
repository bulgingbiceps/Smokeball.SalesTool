using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Smokeball.SalesTool.Test.Shared
{
    internal class ResourceHelper
    {
        public static string GetRsourceAsString(string relativeResourcePath)
        {
            if (string.IsNullOrEmpty(relativeResourcePath))
                throw new ArgumentNullException(nameof(relativeResourcePath));

            var assembly = Assembly.GetExecutingAssembly();

            var resourcePath = $"{Regex.Replace(assembly.ManifestModule.Name, @"\.(exe|dll)$", string.Empty, RegexOptions.IgnoreCase)}.{relativeResourcePath}";

            var stream = assembly.GetManifestResourceStream(resourcePath);
            if (stream == null)
                throw new ArgumentException($"The specified embedded resource \"{relativeResourcePath}\" is not found.");

            // convert stream to string
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();

            return text;

        }
    }
}
