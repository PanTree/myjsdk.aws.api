using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

public class ProcessCreateResponse
{
    /// <summary>
    ///     流程实例ID
    /// </summary>
    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    ///     业务键，全流程引擎不重复
    /// </summary>
    [JsonProperty("processBusinessKey")]
    [JsonPropertyName("processBusinessKey")]
    public string ProcessBusinessKey { get; set; } = string.Empty;

    /// <summary>
    ///     流程组Id
    /// </summary>
    [JsonProperty("processGroupId")]
    [JsonPropertyName("processGroupId")]
    public string ProcessGroupId { get; set; } = string.Empty;

    /// <summary>
    ///     实例标题
    /// </summary>
    [JsonProperty("title")]
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     实例控制状态
    /// </summary>
    [JsonProperty("controlState")]
    [JsonPropertyName("controlState")]
    public string ControlState { get; set; } = string.Empty;

    /// <summary>
    ///     流程定义ID
    /// </summary>
    [JsonProperty("processDefId")]
    [JsonPropertyName("processDefId")]
    public string ProcessDefId { get; set; } = string.Empty;

    /// <summary>
    ///     流程主版本ID
    /// </summary>
    [JsonProperty("processDefVerId")]
    [JsonPropertyName("processDefVerId")]
    public string ProcessDefVerId { get; set; } = string.Empty;

    /// <summary>
    ///     创建时间(返回时间戳)
    /// </summary>
    [JsonProperty("createTime")]
    [JsonPropertyName("createTime")]
    public long CreateTime { get; set; }

    /// <summary>
    ///     启动时间
    /// </summary>
    [JsonProperty("startTime")]
    [JsonPropertyName("startTime")]
    public long? StartTime { get; set; }

    /// <summary>
    ///     启动时间
    /// </summary>
    [JsonProperty("endTime")]
    [JsonPropertyName("endTime")]
    public long? EndTime { get; set; }

    /// <summary>
    ///     开始节点定义ID,如果多个活动被并发开始，记录第1个
    /// </summary>
    [JsonProperty("startActivityId")]
    [JsonPropertyName("startActivityId")]
    public string StartActivityId { get; set; } = string.Empty;

    /// <summary>
    ///     开始节点任务ID,如果多个活动被并发开始，记录第1个
    /// </summary>
    [JsonProperty("startTaskInstId")]
    [JsonPropertyName("startTaskInstId")]
    public string StartTaskInstId { get; set; } = string.Empty;

    /// <summary>
    ///     结束节点定义ID
    /// </summary>
    [JsonProperty("endActivityId")]
    [JsonPropertyName("endActivityId")]
    public string EndActivityId { get; set; } = string.Empty;

    /// <summary>
    ///     备注
    /// </summary>
    [JsonProperty("remark")]
    [JsonPropertyName("remark")]
    public string? Remark { get; set; } = string.Empty;

    /// <summary>
    ///     是否流程实例
    /// </summary>
    [JsonProperty("isProcess")]
    [JsonPropertyName("isProcess")]
    public bool IsProcess { get; set; } = true;

    /// <summary>
    ///     是否启动
    /// </summary>
    [JsonProperty("isStart")]
    [JsonPropertyName("isStart")]
    public bool IsStart { get; set; }

    /// <summary>
    ///     是否结束
    /// </summary>
    [JsonProperty("isEnd")]
    [JsonPropertyName("isEnd")]
    public bool IsEnd { get; set; }

    /// <summary>
    ///     是否异步处理
    /// </summary>
    [JsonProperty("isAsync")]
    [JsonPropertyName("isAsync")]
    public bool IsAsync { get; set; }

    /// <summary>
    ///     是否异常流程（业务异常/系统异常）
    /// </summary>
    [JsonProperty("isException")]
    [JsonPropertyName("isException")]
    public bool IsException { get; set; }

    /// <summary>
    ///     根据KPI，是否延时流程
    /// </summary>
    [JsonProperty("isOvertime")]
    [JsonPropertyName("isOvertime")]
    public bool IsOvertime { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("subProcess")]
    [JsonPropertyName("subProcess")]
    public bool SubProcess { get; set; }

    /// <summary>
    ///     该实例是否存在子流程
    /// </summary>
    [JsonProperty("existSubProcess")]
    [JsonPropertyName("existSubProcess")]
    public bool ExistSubProcess { get; set; }

    /// <summary>
    ///     启动人UID
    /// </summary>
    [JsonProperty("createUser")]
    [JsonPropertyName("createUser")]
    public string CreateUser { get; set; } = string.Empty;

    /// <summary>
    ///     启动人部门ID
    /// </summary>
    [JsonProperty("createUserDeptId")]
    [JsonPropertyName("createUserDeptId")]
    public string CreateUserDeptId { get; set; } = string.Empty;


    /// <summary>
    ///     启动人角色ID
    /// </summary>
    [JsonProperty("createUserRoleId")]
    [JsonPropertyName("createUserRoleId")]
    public string CreateUserRoleId { get; set; } = string.Empty;

    /// <summary>
    ///     启动人所在的组织结构路径
    /// </summary>
    [JsonProperty("createUserLocation")]
    [JsonPropertyName("createUserLocation")]
    public string CreateUserLocation { get; set; } = string.Empty;

    /// <summary>
    ///     启动人所在的组织ID
    /// </summary>
    [JsonProperty("createUserOrgId")]
    [JsonPropertyName("createUserOrgId")]
    public string CreateUserOrgId { get; set; } = string.Empty;

    /// <summary>
    ///     安全级别
    /// </summary>
    [JsonProperty("securityLayer")]
    [JsonPropertyName("securityLayer")]
    public int SecurityLayer { get; set; }

    /// <summary>
    ///     任务执行消耗的时间
    /// </summary>
    [JsonProperty("executeCostTime")]
    [JsonPropertyName("executeCostTime")]
    public long ExecuteCostTime { get; set; }

    /// <summary>
    ///     任务超时时间（KPI）
    /// </summary>
    [JsonProperty("executeExpireTime")]
    [JsonPropertyName("executeExpireTime")]
    public long ExecuteExpireTime { get; set; }

    // --------子流程-----------------------------------------------------

    /// <summary>
    ///     父流程实例ID(CallActivity、Sub-Process)
    /// </summary>
    [JsonProperty("parentProcessInstId")]
    [JsonPropertyName("parentProcessInstId")]
    public string ParentProcessInstId { get; set; } = string.Empty;

    /// <summary>
    ///     父流程任务实例ID(激活，产生该子流程实例的任务ID)
    /// </summary>
    [JsonProperty("parentTaskInstId")]
    [JsonPropertyName("parentTaskInstId")]
    public string ParentTaskInstId { get; set; } = string.Empty;

    /// <summary>
    ///     子流程配置ID
    /// </summary>
    [JsonProperty("processProfileId")]
    [JsonPropertyName("processProfileId")]
    public string ProcessProfileId { get; set; } = string.Empty;

    /// <summary>
    ///     子流程实例类型，parentTaskInstId&gt;0时适用
    /// </summary>
    [JsonProperty("subInstType")]
    [JsonPropertyName("subInstType")]
    public int SubInstType { get; set; }

    /// <summary>
    ///     业务域ID，该实例属于某类业务域，如电信的OSS、BSS、MSS
    /// </summary>
    [JsonProperty("IOBD")]
    [JsonPropertyName("IOBD")]
    public string Iobd { get; set; } = string.Empty;

    /// <summary>
    ///     组织区域ID，该实例属于某组织区域的业务数据，如中国大陆、东南亚、北美
    /// </summary>
    [JsonProperty("IOR")]
    [JsonPropertyName("IOR")]
    public string Ior { get; set; } = string.Empty;

    /// <summary>
    ///     系统ID，该实例属于某类系统依赖的流程，如营销系统、生产系统、OA系统
    /// </summary>
    [JsonProperty("IOS")]
    [JsonPropertyName("IOS")]
    public string Ios { get; set; } = string.Empty;

    /// <summary>
    ///     自定义ID，这是一个开放的自定义项，可根据管理需要定义规则名称和规则项
    /// </summary>
    [JsonProperty("IOC")]
    [JsonPropertyName("IOC")]
    public string Ioc { get; set; } = string.Empty;

    /// <summary>
    ///     流程被催办的次数
    /// </summary>
    [JsonProperty("remindTimes")]
    [JsonPropertyName("remindTimes")]
    public int RemindTimes { get; set; }
}

