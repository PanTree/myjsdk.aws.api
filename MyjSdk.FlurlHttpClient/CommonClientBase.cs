using Flurl.Http;
using Flurl.Http.Configuration;
using MyjSdk.FlurlHttpClient.Constants;
using MyjSdk.FlurlHttpClient.Interception;

namespace MyjSdk.FlurlHttpClient;

public abstract class CommonClientBase : ICommonClient
{
    protected CommonClientBase(IFlurlClientCache clientCache)
    {
        Interceptors = new FlurlHttpCallInterceptorCollection();

        FlurlClientCache = clientCache.WithDefaults(b =>
        {
            b.BeforeCall(async call =>
            {
                for (int i = 0, len = Interceptors.Count; i < len; i++) await Interceptors[i].BeforeCallAsync(call);
            });
            b.AfterCall(async call =>
            {
                for (int i = 0, len = Interceptors.Count; i < len; i++) await Interceptors[i].AfterCallAsync(call);
            });
        });
    }

    public IFlurlClientCache FlurlClientCache { get; }

    public FlurlHttpCallInterceptorCollection Interceptors { get; }


    public void Configure(IFlurlRequest flurlRequest, Action<CommonClientSettings> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        flurlRequest.WithSettings(furlSettings =>
        {
            var settings = new CommonClientSettings(furlSettings);
            configure.Invoke(settings);
            furlSettings.Timeout = settings.ConnectionRequestTimeout;
            furlSettings.HttpVersion = settings.HttpVersion;
            furlSettings.JsonSerializer = settings.JsonSerializer;
            furlSettings.UrlEncodedSerializer = settings.UrlEncodedSerializer;
            furlSettings.AllowedHttpStatusRange = settings.AllowedHttpStatusRange;
        });
    }

    public virtual async Task<IFlurlResponse> SendRequestAsync(IFlurlRequest flurlRequest,
        HttpContent? httpContent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(flurlRequest);

        return await WrapRequest(flurlRequest).SendAsync(flurlRequest.Verb, httpContent,
            HttpCompletionOption.ResponseContentRead, cancellationToken);
    }

    /// <summary>
    ///     异步发起请求。
    ///     <para>注意：对于非简单请求，如果未指定请求标头 Content-Type，将默认使用 "application/json" 作为其值。</para>
    /// </summary>
    /// <param name="flurlRequest"></param>
    /// <param name="data"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public virtual async Task<IFlurlResponse> SendRequestWithJsonAsync(IFlurlRequest flurlRequest,
        object? data = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(flurlRequest);

        if (data != null && !flurlRequest.Headers.Contains(HttpHeaders.ContentType))
            flurlRequest.WithHeader(HttpHeaders.ContentType, "application/json");

        return await WrapRequest(flurlRequest)
            .SendJsonAsync(flurlRequest.Verb, data, cancellationToken: cancellationToken);
    }

    private IFlurlRequest WrapRequest(IFlurlRequest flurlRequest)
    {
        return flurlRequest
            .AllowAnyHttpStatus();
    }
   
}