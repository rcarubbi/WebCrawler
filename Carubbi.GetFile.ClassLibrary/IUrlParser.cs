using Carubbi.ServiceLocator;
using System.Collections.Generic;

namespace Carubbi.GetFile.ClassLibrary
{
    public interface IUrlParser : IPlugin
    {
        List<DownloadInfo> Parse(string searchTerm, int maxImages);
    }
}
