using System;
using System.IO;
using System.Net;

namespace Carubbi.GetFile.ClassLibrary
{
    public class Downloader
    {
        public Downloader(string from, string to)
        {
            From = from;
            To = to;
        }

        public string From { get; }

        public string To { get; }


        public void Download()
        {
            var success = false;
            while(!success) { 
                using (var client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("user-agent",
                            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36");
                        SaveFile(client.DownloadData(From), Path.GetFileName(new Uri(From).AbsolutePath));
                        success = true;
                    }
                    catch
                    {

                    }
                }
            }
        }


        private void SaveFile(byte[] data, string fileName)
        {
             
            if (!Directory.Exists(To))
            {
                Directory.CreateDirectory(To ?? throw new InvalidOperationException());
            }

            var file = Path.Combine(To, fileName);
            if (File.Exists(file)) return;

            File.WriteAllBytes(file, data);
        }
    }
}
