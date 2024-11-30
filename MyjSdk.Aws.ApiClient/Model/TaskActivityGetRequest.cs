using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyjSdk.Aws.ApiClient.Model;

public class TaskActivityGetRequest : MyjAwsApiRequest, IInferable<TaskActivityGetRequest, MyjAwsApiResponse<TaskActivityResponse>>
{
    /// <summary>
    /// 一个合法的AWS会话
    /// </summary>
    [JsonProperty("sid")]
    [JsonPropertyName("sid")]
    public string? Sid { get; set; } = string.Empty;

    /// <summary>
    /// 流程实例定义ID                          
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public string ProcessInstId { get; set; } = string.Empty;

}