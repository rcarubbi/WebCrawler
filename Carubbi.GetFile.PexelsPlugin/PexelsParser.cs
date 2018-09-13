using Carubbi.GetFile.ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Carubbi.GetFile.PexelsPlugin
{
    public class PexelsParser : IUrlParser
    {
        private string BaseUrl { get; } = "https://www.pexels.com/search/{0}/?page={1}&format=js";
        public string Name { get; } = "Pexels Image Downloader";


        public List<DownloadInfo> Parse(string searchTerm, int maxImages)
        {
            var fileNames = new List<string>();
            var urlsFound = new List<DownloadInfo>();
            var page = 1;
            const string pattern = @"(https?:\/\/[^\s]+)";

            while (urlsFound.Count < maxImages)
            {
                var url = string.Format(BaseUrl, searchTerm, page);
                try
                {
                    using (var client = new WebClient())
                    {
                        client.Headers.Add("user-agent",
                            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36");
                        var response = client.DownloadString(url);
                        var matches = Regex.Matches(response, pattern);
                        if (matches.Count == 0)
                        {
                            break;
                        }

                        foreach (Match m in matches)
                        {
                            var fileName = Path.GetFileName(new Uri(m.Value).AbsolutePath);
                            if (fileNames.Contains(fileName)) continue;
                            urlsFound.Add(new DownloadInfo()
                            {
                                Url = m.Value,
                                OutputFileName = Path.GetFileName(new Uri(m.Value).AbsolutePath)
                            });
                            fileNames.Add(fileName);
                        }
                        page++;
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return urlsFound.Take(maxImages).ToList();
        }
    }
}
