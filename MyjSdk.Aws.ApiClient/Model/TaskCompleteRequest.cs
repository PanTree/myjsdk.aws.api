using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyjSdk.Aws.ApiClient.Model;

public class TaskCompleteRequest : MyjAwsApiRequest, IInferable<TaskCompleteRequest, MyjAwsApiResponse<Dictionary<string, object>>>
{
    /// <summary>
    /// 任务实例Id                        
    /// </summary>
    [JsonProperty("taskInstId")]
    [JsonPropertyName("taskInstId")]
    public string TaskInstId { get; set; } = string.Empty;

    /// <summary>
    ///一个合法的AWS登录账户名
    /// </summary>
    [JsonProperty("uid")]
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    /// <summary>
    /// 	流程变量键值对
    /// </summary>
    [JsonProperty("vars")]
    [JsonPropertyName("vars")]
    public string Vars { get; set; } = string.Empty;

    /// <summary>
    /// 如果评估可以达成向后推进的条件，是否继续自动向下执行。
    /// 如果开发者不希望干扰后继的路线的执行， 应提供true值。该选项对传阅、加签等非常规任务无效
    /// </summary>
    [JsonProperty("isBranch")]
    [JsonPropertyName("isBranch")]
    public bool IsBranch { get; set; } = true;

    /// <summary>
    /// 是否遇到人工任务时暂停创建，继而由外部API根据用户选择执行人范围后再创建
    /// </summary>
    [JsonProperty("isBreakUserTask")]
    [JsonPropertyName("isBreakUserTask")]
    public bool IsBreakUserTask { get; set; }
}


