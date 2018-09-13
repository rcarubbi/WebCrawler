using Carubbi.GetFile.ClassLibrary;
using Carubbi.Vimeo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace Carubbi.GetFile.VimeoPlugin
{
    public class VimeoPlugin : IUrlParser
    {
        private readonly string _accessToken = "ad6c45d41ead255428d510efb314e473";
        public string Name { get; } = "Vimeo Video Downloader";

        const string urlBase = "https://player.vimeo.com/{0}/config";

        public List<DownloadInfo> Parse(string searchTerm, int maxImages)
        {
            var vimeoClient = new Client(_accessToken);
            var urlsFound = new List<DownloadInfo>();
            var page = 1;
            var filenames = new List<string>();

            while (urlsFound.Count < maxImages)
            {

                try
                {
                    var results = vimeoClient.Query(searchTerm, page);

                    foreach (var result in results.data)
                    {
                        using (var client = new WebClient())
                        {
                            var response =
                                client.DownloadString(string.Format(urlBase, result.uri.Replace("/videos", "video")));
                            var details = JsonConvert.DeserializeObject<ResponseModels.RootObject>(response);

                            if (details.request.files.progressive.Count <= 0) continue;

                            var fileName =
                                Path.GetFileName(new Uri(details.request.files.progressive[0].url).AbsolutePath);
                            if (filenames.Contains(fileName)) continue;
                            urlsFound.Add(new DownloadInfo
                            {
                                Url = details.request.files.progressive[0].url,
                                OutputFileName = fileName
                            });
                            filenames.Add(fileName);
                        }
                    }
                    page++;

                }
                catch(Exception ex)
                {
                    // ignored
                }
            }

            return urlsFound.Take(maxImages).ToList();



        }
    }
}
