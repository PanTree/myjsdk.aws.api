using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

public class TaskRollbackRequest : MyjAwsApiRequest,
    IInferable<TaskRollbackRequest, MyjAwsApiResponse<TaskInstanceResponse>>
{
    /// <summary>
    ///     回退任务实例Id，该任务必须是一个活动任务
    /// </summary>
    [JsonProperty("taskInstId")]
    [JsonPropertyName("taskInstId")]
    public string TaskInstId { get; set; } = string.Empty;

    /// <summary>
    ///     目标节点定义ID，必须是一个历史处理过的路径
    /// </summary>
    [JsonProperty("targetActivityId")]
    [JsonPropertyName("targetActivityId")]
    public string TargetActivityId { get; set; }=string.Empty;

    /// <summary>
    ///     一个合法的AWS登录账户名
    /// </summary>
    [JsonProperty("uid")]
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;

    /// <summary>
    ///     是否执行补偿事件
    /// </summary>
    [JsonProperty("isCompensation")]
    [JsonPropertyName("isCompensation")]
    public bool IsCompensation { get; set; }

    /// <summary>
    ///     回退原因
    /// </summary>
    [JsonProperty("rollbackReason")]
    [JsonPropertyName("rollbackReason")]
    public string RollbackReason { get; set; }=string.Empty;
}

