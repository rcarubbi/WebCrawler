using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.Win32;

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

        public static string GetDefaultExtension(string mimeType)
        {
            var key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
            var value = key?.GetValue("Extension", null);
            var result = value != null ? value.ToString() : string.Empty;

            return result;
        }

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
                        var data = client.DownloadData(From);
                        var to = To;
                        var fileName = Path.GetFileName(new Uri(To).AbsolutePath);
                        if (!Path.HasExtension(fileName))
                        {
                            var mimeType = client.ResponseHeaders["content-type"];
                            fileName += GetDefaultExtension(mimeType);
                            to = Path.Combine(Path.GetDirectoryName(to), fileName);
                        }

                        SaveFile(data, to);
                        
                        success = true;
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
        }


        private void SaveFile(byte[] data, string fileName)
        {
            var directory = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(fileName)) return;
            File.WriteAllBytes(fileName, data);
        }
    }
}
