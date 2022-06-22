using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MimeSharp
{
    public class MimeSharp
    {
        private Dictionary<string, List<string>> apacheMimes = new Dictionary<string, List<string>>();

        private readonly string defaultType = "application/octet-stream";

        public MimeSharp()
        {
            var mimeTypes = Path.Combine("MimeTypes", "mime.types");

            using (StreamReader streamReader = new StreamReader(mimeTypes))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

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

                        apacheMimes.Add(matches.First(), matches.Skip(1).ToList());
                    }
                }
            }
        }

        public string Lookup(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            //remove dot from extenstion to lookup in the dictionary
            extension = extension.Substring(1);

            var mimeType = apacheMimes.FirstOrDefault(x => x.Value.Exists(m => m.Contains(extension))).Key;
            if (string.IsNullOrEmpty(mimeType))
                return defaultType;
            return mimeType;
        }

        public string DefaultType()
        {
            return defaultType;
        }

        public List<string> Extension(string mimeType)
        {
            var extensions = apacheMimes.FirstOrDefault(x => x.Key.Equals(mimeType)).Value;
            if (extensions == null)
                return new List<string>();
            return extensions;
        }
    }
}