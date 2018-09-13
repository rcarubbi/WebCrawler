using Carubbi.ServiceLocator;
using System.Collections.Generic;

namespace Carubbi.ImageDownloader
{
    public interface IUrlParser : IPlugin
    {
        List<string> Parse(string searchTerm, int maxImages);
    }
}
