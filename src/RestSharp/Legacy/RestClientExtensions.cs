using System;
using System.Threading.Tasks;

namespace RestSharp
{
    public partial class RestClientExtensions
    {
        [Obsolete("Use GetAsync")]
        public static Task<T> GetTaskAsync<T>(this IRestClient client, IRestRequest request) where T : new()
            => client.ExecuteGetTaskAsync<T>(request).ContinueWith(x => x.Result.Data);

        [Obsolete("Use PostAsync")]
        public static Task<T> PostTaskAsync<T>(this IRestClient client, IRestRequest request) where T : new()
            => client.ExecutePostTaskAsync<T>(request).ContinueWith(x => x.Result.Data);

        [Obsolete("Use PutAsync")]
        public static Task<T> PutTaskAsync<T>(this IRestClient client, IRestRequest request) where T : new()
            => client.ExecuteTaskAsync<T>(request, Method.PUT).ContinueWith(x => x.Result.Data);

        [Obsolete("Use HeadAsync")]
        public static Task<T> HeadTaskAsync<T>(this IRestClient client, IRestRequest request) where T : new()
            => client.ExecuteTaskAsync<T>(request, Method.HEAD).ContinueWith(x => x.Result.Data);

        [Obsolete("Use OptionsAsync")]
        public static Task<T> OptionsTaskAsync<T>(this IRestClient client, IRestRequest request) where T : new()
            => client.ExecuteTaskAsync<T>(request, Method.OPTIONS).ContinueWith(x => x.Result.Data);

        [Obsolete("Use PatchAsync")]
        public static Task<T> PatchTaskAsync<T>(this IRestClient client, IRestRequest request) where T : new()
            => client.ExecuteTaskAsync<T>(request, Method.PATCH).ContinueWith(x => x.Result.Data);

        [Obsolete("Use DeleteAsync")]
        public static Task<T> DeleteTaskAsync<T>(this IRestClient client, IRestRequest request) where T : new()
            => client.ExecuteTaskAsync<T>(request, Method.DELETE).ContinueWith(x => x.Result.Data);

        /// <summary>
        ///     Executes the request and callback asynchronously, authenticating if needed
        /// </summary>
        /// <param name="client">The IRestClient this method extends</param>
        /// <param name="request">Request to be executed</param>
        /// <param name="callback">Callback function to be executed upon completion</param>
        public static RestRequestAsyncHandle ExecuteAsync(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse> callback
        )
            => client.ExecuteAsync(request, (response, handle) => callback(response));

        /// <summary>
        ///     Executes the request and callback asynchronously, authenticating if needed
        /// </summary>
        /// <param name="client">The IRestClient this method extends</param>
        /// <typeparam name="T">Target deserialization type</typeparam>
        /// <param name="request">Request to be executed</param>
        /// <param name="callback">Callback function to be executed upon completion providing access to the async handle</param>
        public static RestRequestAsyncHandle ExecuteAsync<T>(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse<T>> callback
        ) where T : new()
            => client.ExecuteAsync<T>(request, (response, asyncHandle) => callback(response));

        public static RestRequestAsyncHandle GetAsync<T>(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse<T>, RestRequestAsyncHandle> callback
        ) where T : new()
            => client.ExecuteAsync(request, callback, Method.GET);

        public static RestRequestAsyncHandle PostAsync<T>(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse<T>, RestRequestAsyncHandle> callback
        ) where T : new()
            => client.ExecuteAsync(request, callback, Method.POST);

        public static RestRequestAsyncHandle PutAsync<T>(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse<T>, RestRequestAsyncHandle> callback
        ) where T : new()
            => client.ExecuteAsync(request, callback, Method.PUT);

        public static RestRequestAsyncHandle HeadAsync<T>(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse<T>, RestRequestAsyncHandle> callback
        ) where T : new()
            => client.ExecuteAsync(request, callback, Method.HEAD);

        public static RestRequestAsyncHandle OptionsAsync<T>(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse<T>, RestRequestAsyncHandle> callback
        ) where T : new()
            => client.ExecuteAsync(request, callback, Method.OPTIONS);

        public static RestRequestAsyncHandle PatchAsync<T>(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse<T>, RestRequestAsyncHandle> callback
        ) where T : new()
            => client.ExecuteAsync(request, callback, Method.PATCH);

        public static RestRequestAsyncHandle DeleteAsync<T>(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse<T>, RestRequestAsyncHandle> callback
        ) where T : new()
            => client.ExecuteAsync(request, callback, Method.DELETE);

        public static RestRequestAsyncHandle GetAsync(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse, RestRequestAsyncHandle> callback
        )
            => client.ExecuteAsync(request, callback, Method.GET);

        public static RestRequestAsyncHandle PostAsync(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse, RestRequestAsyncHandle> callback
        )
            => client.ExecuteAsync(request, callback, Method.POST);

        public static RestRequestAsyncHandle PutAsync(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse, RestRequestAsyncHandle> callback
        )
            => client.ExecuteAsync(request, callback, Method.PUT);

        public static RestRequestAsyncHandle HeadAsync(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse, RestRequestAsyncHandle> callback
        )
            => client.ExecuteAsync(request, callback, Method.HEAD);

        public static RestRequestAsyncHandle OptionsAsync(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse, RestRequestAsyncHandle> callback
        )
            => client.ExecuteAsync(request, callback, Method.OPTIONS);

        public static RestRequestAsyncHandle PatchAsync(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse, RestRequestAsyncHandle> callback
        )
            => client.ExecuteAsync(request, callback, Method.PATCH);

        public static RestRequestAsyncHandle DeleteAsync(
            this IRestClient client,
            IRestRequest request,
            Action<IRestResponse, RestRequestAsyncHandle> callback
        )
            => client.ExecuteAsync(request, callback, Method.DELETE);
    }
}