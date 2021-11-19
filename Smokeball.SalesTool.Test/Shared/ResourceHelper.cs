using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.Test.Shared
{
    public class ResourceHelper
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
