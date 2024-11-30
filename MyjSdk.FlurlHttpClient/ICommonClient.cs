using Flurl.Http;
using Flurl.Http.Configuration;
using MyjSdk.FlurlHttpClient.Interception;

namespace MyjSdk.FlurlHttpClient;

public interface ICommonClient 
{
    /// <summary>
    /// 获取当前客户端的拦截器集合。
    /// </summary>
    FlurlHttpCallInterceptorCollection Interceptors { get; }

   

    IFlurlClientCache FlurlClientCache { get; }

    /// <summary>
    /// 配置客户端。
    /// </summary>
    /// <param name="configure"></param>
    void Configure(IFlurlRequest flurlRequest, Action<CommonClientSettings> configure);


    Task<IFlurlResponse> SendRequestAsync(IFlurlRequest flurlRequest,
      HttpContent? httpContent = null, CancellationToken cancellationToken = default);

    Task<IFlurlResponse> SendRequestWithJsonAsync(IFlurlRequest flurlRequest,
        object? data = null, CancellationToken cancellationToken = default);
}