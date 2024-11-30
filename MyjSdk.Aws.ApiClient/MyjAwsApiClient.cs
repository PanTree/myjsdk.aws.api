using System.Collections.ObjectModel;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Logging;
using MyjSdk.Aws.ApiClient.Interceptors;
using MyjSdk.Aws.ApiClient.Setting;
using MyjSdk.FlurlHttpClient;
using MyjSdk.FlurlHttpClient.Extensions;
using Volo.Abp;

namespace MyjSdk.Aws.ApiClient;

public class MyjAwsApiClient : CommonClientBase
{
    public MyjAwsApiClient(MyjAwsApiClientOptions options, IFlurlClientCache clientCache, ILogger? logger = null) :
        base(clientCache)
    {
        ArgumentNullException.ThrowIfNull(options);

        Credentials = new Credentials(options);
        Endpoint = options.Endpoint;
        FlurlClient = FlurlClientCache.GetOrAdd(Credentials.AccessKey, options.Endpoint, builder =>
        {
            builder.Settings.Timeout = TimeSpan.FromMilliseconds(options.Timeout);
            // _.WithBasicAuth(Credentials.AccessKey, Credentials.AppSecret);
        });
        Interceptors.Add(new MyjAwsApiClientInterceptor(options.AccessKey, options.AppSecret, logger,
            AuthorizationType.BasicAuth));
    }

    public IFlurlClient FlurlClient { get; }

    /// <summary>
    ///     凭证
    /// </summary>
    public Credentials Credentials { get; }

    /// <summary>
    ///     请求地址
    /// </summary>
    protected internal string Endpoint { get; }

    public IFlurlRequest CreateRequest(MyjAwsApiRequest request, HttpMethod method, params object[] urlSegments)
    {
        var flurlRequest = FlurlClient.Request(urlSegments).WithVerb(method);

        if (request.Timeout != null) flurlRequest.WithTimeout(TimeSpan.FromMilliseconds(request.Timeout.Value));

        return flurlRequest;
    }

    /// <summary>
    ///     异步发起请求。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="flurlRequest"></param>
    /// <param name="httpContent"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<T> SendRequestAsync<T>(IFlurlRequest flurlRequest, HttpContent? httpContent = null,
        CancellationToken cancellationToken = default)
        where T : MyjAwsApiResponse, new()
    {
        if (flurlRequest == null) throw new ArgumentNullException(nameof(flurlRequest));

        try
        {
            using var flurlResponse = await SendRequestAsync(flurlRequest, httpContent, cancellationToken);
            //  return await _commonClient.WrapResponseWithJsonAsync<T>(flurlResponse, cancellationToken);
            var result = await flurlResponse.GetJsonAsync<T>();
            result.RawBytes = await flurlResponse.GetBytesAsync();
            result.RawHeaders = new ReadOnlyDictionary<string, string>(
                flurlResponse.Headers
                    .GroupBy(e => e.Name)
                    .ToDictionary(
                        k => k.Key,
                        v => string.Join(",", v.Select(e => e.Value)),
                        StringComparer.OrdinalIgnoreCase
                    )
            );
            result.RawStatus = flurlResponse.StatusCode;
            return result;
        }
        catch (FlurlHttpTimeoutException ex)
        {
            throw new AbpException($"请求超时:[{ex.Message}]", ex);
        }
        catch (FlurlHttpException ex)
        {
            throw new AbpException(ex.Message, ex);
        }
    }

    public async Task<T> SendRequestWithJsonAsync<T>(IFlurlRequest flurlRequest, object? data = null,
        CancellationToken cancellationToken = default)
        where T : MyjAwsApiResponse, new()
    {
        if (flurlRequest == null) throw new ArgumentNullException(nameof(flurlRequest));
        try
        {
            var isSimpleRequest = data == null ||
                                  flurlRequest.Verb == HttpMethod.Get ||
                                  flurlRequest.Verb == HttpMethod.Head ||
                                  flurlRequest.Verb == HttpMethod.Options;
            using var flurlResponse = isSimpleRequest
                ? await SendRequestAsync(flurlRequest, null, cancellationToken)
                : await SendRequestWithJsonAsync(flurlRequest, data, cancellationToken);
            var result = await flurlResponse.GetJsonAsync<T>();
            result.RawBytes = await flurlResponse.GetBytesAsync();
            result.RawHeaders = new ReadOnlyDictionary<string, string>(
                flurlResponse.Headers
                    .GroupBy(e => e.Name)
                    .ToDictionary(
                        k => k.Key,
                        v => string.Join(",", v.Select(e => e.Value)),
                        StringComparer.OrdinalIgnoreCase
                    )
            );
            result.RawStatus = flurlResponse.StatusCode;
            return result;
        }
        catch (FlurlHttpTimeoutException ex)
        {
            throw new AbpException(ex.Message, ex);
        }
        catch (FlurlHttpException ex)
        {
            throw new AbpException(ex.Message, ex);
        }
    }
}