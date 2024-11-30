using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using MyjSdk.Aws.ApiClient.Model;

namespace MyjSdk.Aws.ApiClient.Extensions;

/// <summary>
///     任务实例控制(Task Instance)接口
/// </summary>
public static class TaskClientExtensions
{
    /// <summary>
    ///     提交流程变量数据，完成任务
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<Dictionary<string, object>>> ExecuteTaskCompleteAsync(
        this MyjAwsApiClient client,
        TaskCompleteRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "task.complete" },
            { "taskInstId", request.TaskInstId },
            { "uid", request.Uid },
            { "vars", request.Vars },
            { "isBranch", request.IsBranch.ToString() },
            { "isBreakUserTask", request.IsBreakUserTask.ToString() }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<Dictionary<string, object>>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     回退任务到目标节点
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<TaskInstanceResponse>> ExecuteTaskRollBackAsync(
        this MyjAwsApiClient client,
        TaskRollbackRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "task.rollback" },
            { "taskInstId", request.TaskInstId },
            { "targetActivityId", request.TargetActivityId },
            { "uid", request.Uid },
            { "isCompensation", request.IsCompensation.ToString() },
            { "rollbackReason", request.RollbackReason }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<TaskInstanceResponse>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     查询活动任务
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<List<TaskInstanceResponse>>> ExecuteTaskQueryAsync(
        this MyjAwsApiClient client,
        TaskQueryRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var tqm = JsonSerializer.Serialize(request, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "task.query" },
            { "tqm", tqm }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<List<TaskInstanceResponse>>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    ///     查询历史任务
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<List<HistoryTaskInstance>>> ExecuteTaskHistoryQueryPageAsync(
        this MyjAwsApiClient client,
        TaskHistoryQueryPageRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var tqm = JsonSerializer.Serialize(request, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "task.history.query.page" },
            { "firstRow", request.FirstRow.ToString() },
            { "rowCount", request.RowCount.ToString() },
            { "tqm", tqm }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<List<HistoryTaskInstance>>>(fRequest, httpContent,
            cancellationToken);
    }
    /// <summary>
    /// 寻找两个任务间的全部任务实例。
    /// 算法从endTaskInstance向前按path路径来找
    /// </summary>
    public static async Task<MyjAwsApiResponse<List<HistoryTaskInstance>>> ExecuteTaskPresGetAsync(this MyjAwsApiClient client, TaskPresGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var tqm = JsonSerializer.Serialize(request, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "task.pres.get" },
            { "beginTaskInstId", request.BeginTaskInstId },
            { "endTaskInstId", request.EndTaskInstId }
           
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<List<HistoryTaskInstance>>>(fRequest, httpContent,
            cancellationToken);
    }

    /// <summary>
    /// 获取流程任务实例集合
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<TaskActivityResponse>> ExecuteTaskActivityGetAsync(this MyjAwsApiClient client,
        TaskActivityGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "com.awspaas.user.apps.app20230602110119.getTask" },
            { "sid", request.Sid },
            { "processInstId", request.ProcessInstId }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client
                .CreateRequest(request, HttpMethod.Post, "portal", "r","jd")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<TaskActivityResponse>>(fRequest, httpContent,
            cancellationToken);
    }
}