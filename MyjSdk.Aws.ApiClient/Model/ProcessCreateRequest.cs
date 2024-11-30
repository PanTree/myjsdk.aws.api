using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

public class ProcessCreateRequest : MyjAwsApiRequest,
    IInferable<ProcessCreateRequest, MyjAwsApiResponse<ProcessCreateResponse>>
{
    /// <summary>
    ///     流程定义ID
    /// </summary>
    [JsonProperty("processDefId")]
    [JsonPropertyName("processDefId")]
    public virtual string ProcessDefId { get; set; } = string.Empty;

    /// <summary>
    ///     一个合法的AWS登录账户名
    /// </summary>
    [JsonProperty("uid")]
    [JsonPropertyName("uid")]
    public virtual string Uid { get; set; } = string.Empty;

    /// <summary>
    ///     流程标题
    /// </summary>
    [JsonProperty("title")]
    [JsonPropertyName("title")]
    public virtual string Title { get; set; } = string.Empty;

    /// <summary>
    ///     外部业务系统数据主键标识值或一个组合值，在工作流引擎实例表中全局不能重复
    /// </summary>
    [JsonProperty("processBusinessKey")]
    [JsonPropertyName("processBusinessKey")]
    public virtual string ProcessBusinessKey { get; set; } = string.Empty;

    /// <summary>
    ///     启动者所在的部门ID
    /// </summary>
    [JsonProperty("createUserDeptId")]
    [JsonPropertyName("createUserDeptId")]
    public virtual string CreateUserDeptId { get; set; } = string.Empty;

    /// <summary>
    ///     启动者的角色ID
    /// </summary>
    [JsonProperty("createUserRoleId")]
    [JsonPropertyName("createUserRoleId")]
    public virtual string CreateUserRoleId { get; set; } = string.Empty;


    /// <summary>
    ///     流程变量键值对
    /// </summary>
    [JsonProperty("vars")]
    [JsonPropertyName("vars")]
    public virtual Dictionary<string, object?> Vars { get; set; } = new();
}

public class ProcessStartRequest : MyjAwsApiRequest,
    IInferable<ProcessCreateRequest, MyjAwsApiResponse>
{
    /// <summary>
    ///     流程定义ID
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public virtual string ProcessInstId { get; set; } = string.Empty;

    /// <summary>
    ///     流程定义ID
    /// </summary>
    [JsonProperty("startEventDefId")]
    [JsonPropertyName("startEventDefId")]
    public virtual string StartEventDefId { get; set; } = string.Empty;
}

public class ProcessSuspendRequest : MyjAwsApiRequest,
    IInferable<ProcessCreateRequest, MyjAwsApiStructResponse<bool>>
{
    /// <summary>
    ///     流程定义ID
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public virtual string ProcessInstId { get; set; } = string.Empty;
}