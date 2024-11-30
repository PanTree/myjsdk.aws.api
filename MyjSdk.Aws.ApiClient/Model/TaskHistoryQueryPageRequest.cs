
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyjSdk.Aws.ApiClient.Model;

public class TaskHistoryQueryPageRequest :TaskQueryRequest
{
    /// <summary>
    ///     首记录（&gt;=0）
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public int FirstRow { get; set; } = 0;

    /// <summary>
    ///     页面大小
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public int RowCount { get; set; } = 10;
}

public class TaskPresGetRequest : MyjAwsApiRequest
{

    /// <summary>
    ///    起始点任务实例Id                          
    /// </summary>
    [JsonProperty("beginTaskInstId")]
    [JsonPropertyName("beginTaskInstId")]
    public string BeginTaskInstId { get; set; } = string.Empty;
    /// <summary>
    /// 	结束点任务实例Id                        
    /// </summary>
    [JsonProperty("endTaskInstId")]
    [JsonPropertyName("endTaskInstId")]
    public string EndTaskInstId { get; set; } = string.Empty;
}