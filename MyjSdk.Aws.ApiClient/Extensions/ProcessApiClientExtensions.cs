using System.Text.Json;
using MyjSdk.Aws.ApiClient.Model;

namespace MyjSdk.Aws.ApiClient.Extensions;

/// <summary>
///     流程实例控制
/// </summary>
public static class ProcessApiClientExtensions
{
    /// <summary>
    ///     创建一个流程实例
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<MyjAwsApiResponse<ProcessCreateResponse>> ExecutePrecessCreateAsync(
        this MyjAwsApiClient client,
        ProcessCreateRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.create" },
            { "processDefId", request.ProcessDefId },
            { "uid", request.Uid },
            { "title", request.Title },
            { "processBusinessKey", request.ProcessBusinessKey },
            { "createUserDeptId", request.CreateUserDeptId },
            { "createUserRoleId", request.CreateUserRoleId },
            { "vars", JsonSerializer.Serialize(request.Vars) }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<ProcessCreateResponse>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     通过id启动流程
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse> ExecutePrecessStartAsync(
        this MyjAwsApiClient client,
        ProcessStartRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.start" },
            { "processInstId", request.ProcessInstId },
            { "processInst", JsonSerializer.Serialize(new { id = request.ProcessInstId }) },
            { "startEventDefId", request.StartEventDefId }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     流程挂起
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiStructResponse<bool>> ExecutePrecessSuspendAsync(
        this MyjAwsApiClient client,
        ProcessSuspendRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.suspend" },
            { "processInstId", request.ProcessInstId }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiStructResponse<bool>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     通过id恢复被挂起的流程实例
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiStructResponse<bool>> ExecutePrecessResumeAsync(
        this MyjAwsApiClient client,
        ProcessSuspendRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.resume" },
            { "processInstId", request.ProcessInstId }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;

        return await client.SendRequestAsync<MyjAwsApiStructResponse<bool>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     通过id删除流程实例
    ///     <para>与流程实例(及子流程实例嵌套)相关的业务数据、控制数据、变量等全部删除</para>
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiStructResponse<bool>> ExecutePrecessDeleteAsync(this MyjAwsApiClient client,
        ProcessTerminateRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.delete" },
            { "processInstId", request.ProcessInstId },
            { "uid", request.Uid }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiStructResponse<bool>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     通过id取消流程
    ///     <para>终止并补偿一个流程实例。强行终止流程各分支活动的任务和活动令牌，然后执行close操作。</para>
    ///     <para>在终止时， 执行任务定义的补偿事件 。若此时有任务未处理完，将终止的任务转换到H表，其controlstate状态被标记为cancel</para>
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse> ExecutePrecessCancelAsync(this MyjAwsApiClient client,
        ProcessTerminateRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.cancel" },
            { "processInstId", request.ProcessInstId },
            { "uid", request.Uid }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     通过id流程复活，重新激活已结束的流程实例
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<TaskInstanceResponse>> ExecutePrecessReActivateAsync(
        this MyjAwsApiClient client,
        ProcessReactivateRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.reactivate" },
            { "processInstId", request.ProcessInstId },
            { "targetActivityId", request.TargetActivityId },
            { "isClearHistory", request.IsClearHistory.ToString() },
            { "uid", request.Uid },
            { "targetUID", request.TargetUID },
            { "reactivateReason", request.ReactivateReason }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<TaskInstanceResponse>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     通过id终止一个流程
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<MyjAwsApiResponse> ExecutePrecessTerminateAsync(this MyjAwsApiClient client,
        ProcessTerminateRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.terminate" },
            { "processInstId", request.ProcessInstId },
            { "uid", request.Uid }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    /// 获取流程变量
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<Dictionary<string, object?>>> ExecutePrecessVarsGetAsync(this MyjAwsApiClient client,
        ProcessBaseRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.vars.get" },
            { "processInstId", request.ProcessInstId },
           
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<Dictionary<string, object?>>>(fRequest, httpContent,
            cancellationToken);

    }
    /// <summary>
    /// 设置流程变量
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse> ExecutePrecessVarSetsAsync(this MyjAwsApiClient client,
        ProcessVarSetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "process.vars.set" },
            { "processInstId", request.ProcessInstId },
            { "vars", JsonSerializer.Serialize(request.Vars) },
           
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<Dictionary<string, object?>>>(fRequest, httpContent,
            cancellationToken);

    }

}