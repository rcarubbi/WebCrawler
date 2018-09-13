using Carubbi.ImageDownloader;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Carubbi.GetFile.PexelsPlugin
{
    public class PexelsParser : IUrlParser
    {
        public string BaseUrl { get; } = "https://www.pexels.com/search/{0}/?page={1}&format=js";
        public string Name { get; } = "Pexels Image Downloader";
        public List<string> Parse(string searchTerm, int maxImages)
        {
            var urlsFound = new List<string>(maxImages);
            var page = 1;
            const string pattern = @"(https?:\/\/[^\s]+)";

            while (urlsFound.Count < maxImages)
            {
                var url = string.Format(BaseUrl, searchTerm, page++);

                using (var client = new WebClient())
                {
                    var response = client.DownloadString(url);

                    foreach (Match m in Regex.Matches(response, pattern))
                    {
                        urlsFound.Add(m.Value);
                    }
                }
            }

            return urlsFound;
        }
    }
}
