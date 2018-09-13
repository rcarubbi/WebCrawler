using System;
using Carubbi.GetFile.ClassLibrary;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Carubbi.GetFile.UnsplashPlugin
{
    public class UnsplashParser : IUrlParser
    {
        private string BaseUrl { get; } = "https://unsplash.com/napi/search/photos?query={0}&page={1}";
        public string Name { get; } = "Unsplash Image Downloader";
        public List<DownloadInfo> Parse(string searchTerm, int maxImages)
        {
         
            var urlsFound = new List<DownloadInfo>();
            var page = 1;
             

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
                        var root = JsonConvert.DeserializeObject<ResponseModels.RootObject>(response);
 
                        foreach (var result in root.results)
                        {
                          
                            urlsFound.Add(new DownloadInfo{ Url = result.urls.raw, OutputFileName = Path.GetFileName(new Uri(result.urls.raw).AbsolutePath) });
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
