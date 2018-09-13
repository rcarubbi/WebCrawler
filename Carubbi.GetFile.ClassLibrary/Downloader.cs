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
            using (var client = new WebClient())
            {
                SaveFile(client.DownloadData(From));
            }
        }


        private void SaveFile(byte[] data)
        {
            var folder = Path.GetDirectoryName(To);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder ?? throw new InvalidOperationException());
            }

            if (File.Exists(To)) return;

            File.WriteAllBytes(To, data);
        }
    }
}
