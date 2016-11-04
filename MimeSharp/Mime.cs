using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace MimeSharp
{
    public static class Mime
    {
        static readonly Dictionary<string, List<string>> ApacheMimes = new Dictionary<string, List<string>>();

        private static readonly string defaultType = "application/octet-stream";
        private static bool isInitialized = false;
        private static object padLock = new object();

        static Mime()
        {
            Init();
        }

        private static void Init()
        {
            var allApacheMimeTypes = ApacheMimeTypes.AllMimeTypes;

            using (StringReader stringReader = new StringReader(allApacheMimeTypes))
            {
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    //Remove comments
                    var currentLine = Regex.Replace(line, @"\s*#.*|^\s*|\s*$/g", "");

                    //split them by whitespace
                    var stripWhiteSpaceRegEx = new Regex(@"\s+", RegexOptions.None);

                    if (!String.IsNullOrEmpty(currentLine))
                    {
                        var matches = stripWhiteSpaceRegEx.Split(currentLine);

                        //add the mime type and extension to the dictionary
                        //mime-type is the key and value is the list of extensons it is associated with
                        //e.g. {"application/mathematica":["ma","nb","mb"]}

                        ApacheMimes.Add(matches.First(), matches.Skip(1).ToList());

                    }
                }
            }
        }

        public static string Lookup(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();

            //remove dot from extenstion to lookup in the dictionary
            extension = extension.Substring(1);

            // Get an exact match if possible
            var mimeType = ApacheMimes.FirstOrDefault(x => x.Value.Exists(m => m == extension)).Key;
            if (!string.IsNullOrEmpty(mimeType))
                return mimeType;

            // Get a close match
            mimeType = ApacheMimes.FirstOrDefault(x => x.Value.Exists(m => m.Contains(extension))).Key;
            if (string.IsNullOrEmpty(mimeType))
                return defaultType;
            return mimeType;
        }

        public static string DefaultType()
        {
            return defaultType;
        }


        public static List<string> Extension(string mimeType)
        {
            var extensions = ApacheMimes.FirstOrDefault(x => x.Key.Equals(mimeType)).Value;
            if (extensions == null)
                return new List<string>();
            return extensions;
        }

    }
}

