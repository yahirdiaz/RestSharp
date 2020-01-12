using System;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RestSharp.Options
{
    public class HttpOptions
    {
        public static HttpOptions Default => new HttpOptions
        {
            Encoding               = Encoding.UTF8,
            AutomaticDecompression = true,
            FollowRedirects        = true
        };

        /// <summary>
        ///     Enable or disable automatic gzip/deflate decompression
        /// </summary>
        public bool AutomaticDecompression { get; set; }

        /// <summary>
        ///     Maximum number of redirects to follow if FollowRedirects is true
        /// </summary>
        public int? MaxRedirects { get; set; }

        /// <summary>
        ///     UserAgent to be sent with request
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        ///     Timeout in milliseconds to be used for the request
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        ///     The number of milliseconds before the writing or reading times out.
        /// </summary>
        public int ReadWriteTimeout { get;                        set; }
        public bool   PreAuthenticate                      { get; set; }
        public bool   UnsafeAuthenticatedConnectionSharing { get; set; }
        public string BaseHost                             { get; set; }

        /// <summary>
        ///     The System.Net.CookieContainer to be used for the request
        /// </summary>
        public CookieContainer CookieContainer { get; set; }

        /// <summary>
        ///     X509CertificateCollection to be sent with request
        /// </summary>
        public X509CertificateCollection ClientCertificates { get; set; }

        /// <summary>
        ///     Callback function for handling the validation of remote certificates. Useful for certificate pinning and
        ///     overriding certificate errors in the scope of a request.
        /// </summary>
        public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }

        /// <summary>
        ///     Whether or not HTTP 3xx response redirects should be automatically followed
        /// </summary>
        public bool FollowRedirects { get; set; }

        /// <summary>
        ///     Whether or not to use pipelined connections
        /// </summary>
        public bool Pipelined { get; set; }

        /// <summary>
        ///     Determine whether or not the "default credentials" (e.g. the user account under which the current process is
        ///     running) ///     will be sent along to the server.
        /// </summary>
        public bool UseDefaultCredentials { get; set; }

        /// <summary>
        ///     The ConnectionGroupName property enables you to associate a request with a connection group.
        /// </summary>
        public string ConnectionGroupName { get; set; }

        /// <summary>
        ///     Encoding for the request, UTF8 is the default
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.UTF8;

        /// <summary>
        ///     Proxy info to be sent with request
        /// </summary>
        public IWebProxy Proxy { get; set; }

        /// <summary>
        ///     Caching policy for requests created with this wrapper.
        /// </summary>
        public RequestCachePolicy CachePolicy { get; set; }
        
        /// <summary>
        ///     Explicit Host header value to use in requests independent from the request URI.
        ///     If null, default host value extracted from URI is used.
        /// </summary>
        public string Host { get; set; }
        
        public bool KeepAlive { get; set; }
        
        public Version ProtocolVersion { get; set; }
    }
}