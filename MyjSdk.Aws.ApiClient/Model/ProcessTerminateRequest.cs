using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;


public class ProcessBaseRequest : MyjAwsApiRequest,
IInferable<ProcessBaseRequest, MyjAwsApiResponse>{

    /// <summary>
    ///     流程实例ID
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public virtual string ProcessInstId { get; set; } = string.Empty;
}

public class ProcessTerminateRequest : MyjAwsApiRequest,
    IInferable<ProcessTerminateRequest, MyjAwsApiResponse>
{
    /// <summary>
    ///     流程实例ID
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public virtual string ProcessInstId { get; set; } = string.Empty;

    /// <summary>
    ///     一个合法的AWS登录账户名
    /// </summary>
    [JsonProperty("uid")]
    [JsonPropertyName("uid")]
    public virtual string Uid { get; set; } = string.Empty;
}
public class ProcessReactivateRequest : MyjAwsApiRequest,
    IInferable<ProcessReactivateRequest, MyjAwsApiResponse<TaskInstanceResponse>>
{
    /// <summary>
    ///     流程实例ID
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public virtual string ProcessInstId { get; set; } = string.Empty;
    /// <summary>
    ///     激活的目标节点
    /// </summary>
    [JsonProperty("targetActivityId")]
    [JsonPropertyName("targetActivityId")]
    public virtual string TargetActivityId { get; set; } = string.Empty;

    /// <summary>
    ///    是否清空历史处理过程
    /// </summary>
    [JsonProperty("isClearHistory")]
    [JsonPropertyName("isClearHistory")]
    public virtual bool IsClearHistory { get; set; }
    /// <summary>
    ///     一个合法的AWS登录账户名
    /// </summary>
    [JsonProperty("uid")]
    [JsonPropertyName("uid")]
    public virtual string Uid { get; set; } = string.Empty;

    /// <summary>
    ///     如果目标节点是人工任务，需指定任务的参与者
    /// </summary>
    [JsonProperty("targetUID")]
    [JsonPropertyName("targetUID")]
    public virtual string TargetUID { get; set; } = string.Empty;

    /// <summary>
    ///     激活流程的原因
    /// </summary>
    [JsonProperty("reactivateReason")]
    [JsonPropertyName("reactivateReason")]
    public virtual string ReactivateReason { get; set; } = string.Empty;
}

