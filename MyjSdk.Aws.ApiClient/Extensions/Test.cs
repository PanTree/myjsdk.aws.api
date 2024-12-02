namespace MyjSdk.Aws.ApiClient.Extensions;

/// <summary>
///     任务实例控制(Task Instance)接口
/// </summary>
public static class TestExtensions
{

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
            { "isBreakUserTask", request.IsBreakUserTask.ToString()}
        };
        foreach (var key in paramsMap.Keys){
            var value = paramsMap[key]

        }
        using var httpContent = new FormUrlEncodedContent(paramsMap);
        var fRequest = client
                .CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        return await client.SendRequestAsync<MyjAwsApiResponse<Dictionary<string, object>>>(fRequest, httpContent,
            cancellationToken);
    }
}