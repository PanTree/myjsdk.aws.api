using MyjSdk.Aws.ApiClient.Model;

namespace MyjSdk.Aws.ApiClient.Extensions;

/// <summary>
///     AWS模型元数据仓库接口
/// </summary>
public static class RepositoryClientExtensions
{
    /// <summary>
    ///     返回base64字符串
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<string>> ExecuteDiagramGetAsync(this MyjAwsApiClient client,
        DiagramGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);
        
        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "repository.diagram.get" },
            { "processDefId", request.ProcessDefId },
            { "diagramType", request.DiagramType.ToString() }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<string>>(flurlReq, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     返回流程跟踪图的URL
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<string>> ExecuteDiagramUrlGetAsync(this MyjAwsApiClient client,
        DiagramUrlGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "repository.diagramUrl.get" },
            { "processDefId", request.ProcessDefId },
            { "diagramType", request.DiagramType.ToString() },
            { "sid", request.Sid }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<string>>(flurlReq, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     获取流程实例的跟踪URL
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<string>> ExecuteTackUrlGetAsync(this MyjAwsApiClient client,
        TaskUrlGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "repository.trackurl.get" },
            { "processInstId", request.ProcessInstId },
            { "sid", request.Sid }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<string>>(flurlReq, httpContent,
            cancellationToken);
    }


    /// <summary>
    ///     获取流程信息
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<string>> ExecuteProcessGetAsync(this MyjAwsApiClient client,
        RepositoryProcessGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "repository.process.get" },
            { "processDefId", request.ProcessDefId }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<string>>(flurlReq, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     流程扩展属性，一个自定义的字符串
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<string>> ExecuteProcessExtensionGetAsync(this MyjAwsApiClient client,
        RepositoryProcessGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "repository.process.extension.get" },
            { "processDefId", request.ProcessDefId }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<string>>(flurlReq, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     流程扩展属性，一个自定义的字符串
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<string>> ExecuteUserTaskGetAsync(this MyjAwsApiClient client,
        RepositoryUserTaskGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "repository.usertask.get" },
            { "processDefId", request.ProcessDefId },
            { "userTaskDefId", request.UserTaskDefId }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<string>>(flurlReq, httpContent,
            cancellationToken);
    }
    /// <summary>
    /// 获取模型节点
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<ActivityGetResponse>> ExecuteActivityGetAsync(
        this MyjAwsApiClient client, ActivityGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "com.awspaas.user.apps.app20230602110119.getActivity" },
            { "processDefId", request.ProcessDefId },
            { "sid", request.Sid }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "portal", "r", "jd")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<ActivityGetResponse>>(flurlReq, httpContent,
            cancellationToken);
    }
}