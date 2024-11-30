using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

public class FormTrackUrlRequest : MyjAwsApiRequest,
    IInferable<FormTrackUrlRequest, MyjAwsApiResponse<string>>
{
    /// <summary>
    ///     AWS Web服务URL地址
    ///     <para>见PlatformAPI.getPortalUrl。如果为空，默认提供相对路径的URL，如./w</para>
    /// </summary>
    [JsonProperty("bpmPortalHost")]
    [JsonPropertyName("bpmPortalHost")]
    public virtual string BpmPortalHost { get; set; } = string.Empty;

    [JsonProperty("sid")]
    [JsonPropertyName("sid")]
    public virtual string? Sid { get; set; } = string.Empty;

    /// <summary>
    ///     流程实例ID
    /// </summary>
    [JsonProperty("sid")]
    [JsonPropertyName("sid")]
    public virtual string ProcessInstId { get; set; } = string.Empty;

    [JsonProperty("supportCanvas")]
    [JsonPropertyName("supportCanvas")]
    public virtual bool SupportCanvas { get; set; } = true;

    /// <summary>
    ///     平台默认提供的流程跟踪场景可返回该实例的表单，如果开发者需要该功能，需要传入表单信息以便在跟踪图中提供返回表单按钮，一个JSON数据，格式：{"taskInstId":"","openState":""}
    /// </summary>
    [JsonProperty("FormInfo")]
    [JsonPropertyName("FormInfo")]
    public virtual string FormInfo { get; set; } = string.Empty;
}