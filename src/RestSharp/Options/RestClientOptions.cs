using System.Net;
using System.Net.Cache;
using System.Text;

namespace RestSharp.Options
{
    public class RestClientOptions
    {
        public static RestClientOptions Default => new RestClientOptions
        {
            HttpOptions = HttpOptions.Default
        };
        
        public HttpOptions HttpOptions                                { get; set; }
        public bool        UseSynchronizationContext                  { get; set; }
        public bool        ThrowOnDeserializationError                { get; set; }
        public bool        FailOnDeserializationError                 { get; set; }
        public bool        ThrowOnAnyError                            { get; set; }
        public bool        AllowMultipleDefaultParametersWithSameName { get; set; }

        public IWebProxy Proxy { get; set; }

        public RequestCachePolicy CachePolicy { get; set; }
    }
}