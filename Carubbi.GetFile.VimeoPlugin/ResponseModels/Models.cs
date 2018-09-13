using System.Collections.Generic;

namespace Carubbi.GetFile.VimeoPlugin.ResponseModels
{


    public class Progressive
    {

        public string url { get; set; }
    }

    public class Files
    {
      
        public List<Progressive> progressive { get; set; }
    }
     
    public class Request
    {
        public Files files { get; set; }
        
    }

    public class RootObject
    {
        
        public Request request { get; set; }
      
    }
}