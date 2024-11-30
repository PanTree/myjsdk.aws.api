using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyjSdk.Aws.ApiClient.Model;

public class DiagramGetRequest : MyjAwsApiRequest, IInferable<DiagramGetRequest, MyjAwsApiResponse<string>>
{
    /// <summary>
    /// 流程定义ID                          
    /// </summary>
    [JsonProperty("processDefId")]
    [JsonPropertyName("processDefId")]
    public string ProcessDefId { get; set; } = string.Empty;

    /// <summary>
    /// 图类型，0-缩略图；1-原始大图。注意，缩略图是预先生成的，若请求的是大图，每次将根据流程结构动态生成
    /// </summary>
    [JsonProperty("diagramType")]
    [JsonPropertyName("diagramType")]
    public int DiagramType { get; set; } = 1;
}

public class DiagramUrlGetRequest : MyjAwsApiRequest ,IInferable<DiagramUrlGetRequest, MyjAwsApiResponse<string>>
{
    /// <summary>
    /// 流程定义ID                          
    /// </summary>
    [JsonProperty("processDefId")]      
    [JsonPropertyName("processDefId")]                  
    public string ProcessDefId { get; set; } = string.Empty;

    /// <summary>
    /// 图类型，0-缩略图；1-原始大图。注意，缩略图是预先生成的，若请求的是大图，每次将根据流程结构动态生成
    /// </summary>
    [JsonProperty("diagramType")]
    [JsonPropertyName("diagramType")]
    public int DiagramType { get; set; } = 1;
    /// <summary>
    /// 一个合法的AWS会话
    /// </summary>
    [JsonProperty("sid")]
    [JsonPropertyName("sid")]
    public string? Sid { get; set; } = string.Empty;
}
/// <summary>
/// 获取流程实例的跟踪URL
/// </summary>
public class TaskUrlGetRequest : MyjAwsApiRequest, IInferable<TaskUrlGetRequest, MyjAwsApiResponse<string>>
{
    /// <summary>
    /// 流程实例定义ID                          
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public string ProcessInstId { get; set; } = string.Empty;

    /// <summary>
    /// 一个合法的AWS会话
    /// </summary>
    [JsonProperty("sid")]
    [JsonPropertyName("sid")]
    public string? Sid { get; set; } = string.Empty;
}
/// <summary>
/// 获取流程信息
/// </summary>
public class RepositoryProcessGetRequest : MyjAwsApiRequest, IInferable<RepositoryProcessGetRequest, MyjAwsApiResponse<string>>
{
    /// <summary>
    /// 流程定义ID                          
    /// </summary>
    [JsonProperty("processDefId")]
    [JsonPropertyName("processDefId")]
    public string ProcessDefId { get; set; } = string.Empty;
}

public class RepositoryUserTaskGetRequest : MyjAwsApiRequest, IInferable<RepositoryUserTaskGetRequest, MyjAwsApiResponse<string>>
{
    /// <summary>
    /// 流程定义ID                          
    /// </summary>
    [JsonProperty("processDefId")]
    [JsonPropertyName("processDefId")]
    public string ProcessDefId { get; set; } = string.Empty;

    /// <summary>
    /// 返回一个人工任务节点的JSON结构                          
    /// </summary>
    [JsonProperty("userTaskDefId")]
    [JsonPropertyName("userTaskDefId")]
    public string UserTaskDefId { get; set; } = string.Empty;

}

public class ActivityGetRequest : MyjAwsApiRequest, IInferable<ActivityGetRequest, MyjAwsApiResponse<ActivityGetResponse>>
{
    /// <summary>
    /// 流程定义ID                          
    /// </summary>
    [JsonProperty("processDefId")]
    [JsonPropertyName("processDefId")]
    public string ProcessDefId { get; set; } = string.Empty;

    /// <summary>
    /// 一个合法的AWS会话
    /// </summary>
    [JsonProperty("sid")]
    [JsonPropertyName("sid")]
    public string? Sid { get; set; } = string.Empty;
}


