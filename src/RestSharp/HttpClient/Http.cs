using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Authentication;
using RestSharp.Authenticators.OAuth.Extensions;
using RestSharp.Extensions;
using RestSharp.Options;

namespace RestSharp.HttpClient
{
    public class Http : IHttp
    {
        public HttpOptions                   HttpOptions                 { get; }
        public Action<Stream>                ResponseWriter              { get; set; }
        public Action<Stream, IHttpResponse> AdvancedResponseWriter      { get; set; }
        public ICredentials                  Credentials                 { get; set; }
        public bool                          AlwaysMultipartFormData     { get; set; }
        public IList<HttpHeader>             Headers                     { get; }
        public IList<HttpParameter>          Parameters                  { get; }
        public IList<HttpFile>               Files                       { get; }
        public IList<HttpCookie>             Cookies                     { get; }
        public string                        RequestBody                 { get; set; }
        public string                        RequestContentType          { get; set; }
        public byte[]                        RequestBodyBytes            { get; set; }
        public Uri                           Url                         { get; set; }
        public IList<DecompressionMethods>   AllowedDecompressionMethods { get; set; }
        public Action<HttpWebRequest>        WebRequestConfigurator      { get; set; }
        public HttpWebRequest DeleteAsync(Action<HttpResponse> action) => throw new NotImplementedException();

        public HttpWebRequest GetAsync(Action<HttpResponse> action) => throw new NotImplementedException();

        public HttpWebRequest HeadAsync(Action<HttpResponse> action) => throw new NotImplementedException();

        public HttpWebRequest OptionsAsync(Action<HttpResponse> action) => throw new NotImplementedException();

        public HttpWebRequest PostAsync(Action<HttpResponse> action) => throw new NotImplementedException();

        public HttpWebRequest PutAsync(Action<HttpResponse> action) => throw new NotImplementedException();

        public HttpWebRequest PatchAsync(Action<HttpResponse> action) => throw new NotImplementedException();

        public HttpWebRequest MergeAsync(Action<HttpResponse> action) => throw new NotImplementedException();

        public HttpWebRequest AsPostAsync(Action<HttpResponse> action, string httpMethod) => throw new NotImplementedException();

        public HttpWebRequest AsGetAsync(Action<HttpResponse> action, string httpMethod) => throw new NotImplementedException();

        public HttpResponse Delete() => throw new NotImplementedException();

        public HttpResponse Get() => throw new NotImplementedException();

        public HttpResponse Head() => throw new NotImplementedException();

        public HttpResponse Options() => throw new NotImplementedException();

        public HttpResponse Post() => throw new NotImplementedException();

        public HttpResponse Put() => throw new NotImplementedException();

        public HttpResponse Patch() => throw new NotImplementedException();

        public HttpResponse Merge() => throw new NotImplementedException();

        public HttpResponse AsPost(string httpMethod) => throw new NotImplementedException();

        public HttpResponse AsGet(string httpMethod) => throw new NotImplementedException();

        void RunThis(string method, Uri url)
        {
            var webRequest = new HttpClientHandler();
            var request    = new HttpRequestMessage(new HttpMethod(method), url);

            if (HttpOptions.Host != null) request.Headers.Host = HttpOptions.Host;

            // make sure Content-Length header is always sent since default is -1
            if (!HasFiles && !AlwaysMultipartFormData && method != "GET")
            {
                   SetSpecialHeaders(HttpHeaderNames.ContentLength, "0"); 
            }

            if (Credentials != null)
                webRequest.Credentials = Credentials;

            if (HttpOptions.UserAgent.HasValue())
                request.UserAgent = HttpOptions.UserAgent;

            if (HttpOptions.ClientCertificates != null)
                webRequest.ClientCertificates.AddRange(HttpOptions.ClientCertificates);

            AllowedDecompressionMethods.ForEach(x => webRequest.AutomaticDecompression |= x);

            if (HttpOptions.AutomaticDecompression)
                webRequest.AutomaticDecompression =
                    DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None;

            if (HttpOptions.Timeout != 0)
                request.Timeout = HttpOptions.Timeout; // on the client

            webRequest.Credentials = HttpOptions.UseDefaultCredentials ? CredentialCache.DefaultCredentials : Credentials;

            if (HttpOptions.Proxy == null)
            {
                webRequest.UseProxy = false;
            }
            else if (!ReferenceEquals(HttpOptions.Proxy, WebRequest.GetSystemWebProxy()))
            {
                webRequest.Proxy = HttpOptions.Proxy;
            }
            else
            {
                webRequest.DefaultProxyCredentials = HttpOptions.Proxy.Credentials;
            }

            // if (HttpOptions.CachePolicy != null)
            //     webRequest.CachePolicy = HttpOptions.CachePolicy;

            webRequest.AllowAutoRedirect = HttpOptions.FollowRedirects;

            if (HttpOptions.FollowRedirects && HttpOptions.MaxRedirects.HasValue)
                webRequest.MaxAutomaticRedirections = HttpOptions.MaxRedirects.Value;

            webRequest.SslProtocols                   = (SslProtocols) ServicePointManager.SecurityProtocol;
            webRequest.CheckCertificateRevocationList = ServicePointManager.CheckCertificateRevocationList;

            var rcvc = HttpOptions.RemoteCertificateValidationCallback ?? ServicePointManager.ServerCertificateValidationCallback;

            if (rcvc != null)
            {
                var localRcvc = rcvc;
                webRequest.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => localRcvc(this, cert, chain, errors);
            }

            if (HttpOptions.KeepAlive)
            {
                request.Headers.Connection.Add(HttpHeaderNames.KeepAlive);
            }
            else
            {
                request.Headers.ConnectionClose = true;
            }

            request.Version = HttpOptions.ProtocolVersion;

            // Unsupported
            // webRequest.ConnectionGroupName = HttpOptions.ConnectionGroupName;
        }
    }
}