using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

/// <summary>
///     活动的任务实例
/// </summary>
public class TaskInstanceResponse
{
    /// <summary>
    ///     一组任务实例的声明范围，边界事件绑定对象
    /// </summary>
    [JsonProperty("scopeId")]
    [JsonPropertyName("scopeId")]
    public string ScopeId { get; set; } = string.Empty;

    /// <summary>
    ///     活动类型
    /// </summary>
    [JsonProperty("activityType")]
    [JsonPropertyName("activityType")]
    public string ActivityType { get; set; } = string.Empty;

    /// <summary>
    ///     流程实例ID
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public string ProcessInstId { get; set; } = string.Empty;

    /// <summary>
    ///     父任务实例ID
    /// </summary>
    [JsonProperty("parentTaskInstId")]
    [JsonPropertyName("parentTaskInstId")]
    public string ParentTaskInstId { get; set; } = string.Empty;


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
    ///     节点定义ID
    /// </summary>
    [JsonProperty("activityDefId")]
    [JsonPropertyName("activityDefId")]
    public string ActivityDefId { get; set; } = string.Empty;

    /// <summary>
    ///     任务发起
    /// </summary>
    [JsonProperty("owner")]
    [JsonPropertyName("owner")]
    public string Owner { get; set; } = string.Empty;

    /// <summary>
    ///     任务执行人
    /// </summary>
    [JsonProperty("target")]
    [JsonPropertyName("target")]
    public string Target { get; set; } = string.Empty;


    /// <summary>
    ///     任务类型
    /// </summary>
    [JsonProperty("state")]
    [JsonPropertyName("state")]
    public int State { get; set; }

    /// <summary>
    ///     任务控制状态
    /// </summary>
    [JsonProperty("controlState")]
    [JsonPropertyName("controlState")]
    public string ControlState { get; set; } = string.Empty;

    /// <summary>
    ///     任务创建时AWS服务器处理节点，集群时配置的ip:port
    /// </summary>
    [JsonProperty("beginEngineNode")]
    [JsonPropertyName("beginEngineNode")]
    public string BeginEngineNode { get; set; } = string.Empty;

    /// <summary>
    ///     任务认领类型
    /// </summary>
    [JsonProperty("claimType")]
    [JsonPropertyName("claimType")]
    public int ClaimType { get; set; }

    /// <summary>
    ///     任务认领类型的资源ID，如ORG/Dept/Role
    /// </summary>
    [JsonProperty("claimResourceId")]
    [JsonPropertyName("claimResourceId")]
    public string ClaimResourceId { get; set; } = string.Empty;

    /// <summary>
    ///     Activity多例时的调度指令ID
    /// </summary>
    [JsonProperty("dispatchId")]
    [JsonPropertyName("dispatchId")]
    public string DispatchId { get; set; } = string.Empty;


    /// <summary>
    ///     流程组名称
    /// </summary>
    [JsonProperty("processGroupId")]
    [JsonPropertyName("processGroupId")]
    public string ProcessGroupId { get; set; } = string.Empty;

    /// <summary>
    ///     任务发起者所在部门ID，这个部门可能是兼任部门(User Task)
    /// </summary>
    [JsonProperty("ownerDepartmentId")]
    [JsonPropertyName("ownerDepartmentId")]
    public string OwnerDepartmentId { get; set; } = string.Empty;


    /// <summary>
    ///     任务办理者所在单位ID，这个部门可能是兼任部门(User Task)
    /// </summary>
    [JsonProperty("targetCompanyId")]
    [JsonPropertyName("targetCompanyId")]
    public string TargetCompanyId { get; set; } = string.Empty;

    /// <summary>
    ///     任务办理者所在部门ID，这个部门可能是兼任部门(User Task)
    /// </summary>
    [JsonProperty("targetDepartmentId")]
    [JsonPropertyName("targetDepartmentId")]
    public string TargetDepartmentId { get; set; } = string.Empty;

    /// <summary>
    ///     任务办理者角色ID，这个角色可能是兼任角色(User Task)
    /// </summary>
    [JsonProperty("targetRoleId")]
    [JsonPropertyName("targetRoleId")]
    public string TargetRoleId { get; set; } = string.Empty;


    /// <summary>
    ///     是否异步处理
    /// </summary>
    [JsonProperty("async")]
    [JsonPropertyName("async")]
    public bool IsAsync { get; set; }


    /// <summary>
    ///     是否需要监控成本策略
    /// </summary>
    [JsonProperty("monitor")]
    [JsonPropertyName("monitor")]
    public bool IsMonitor { get; set; }

    /// <summary>
    ///     该任务的归档由代理人（与TARGET不同的人）操作
    /// </summary>
    [JsonProperty("delegateUser")]
    [JsonPropertyName("delegateUser")]
    public string DelegateUser { get; set; } = string.Empty;

    /// <summary>
    ///     任务相关的信息，例如错误异常
    /// </summary>
    [JsonProperty("taskInfo")]
    [JsonPropertyName("taskInfo")]
    public string? TaskInfo { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("EAITask")]
    [JsonPropertyName("EAITask")]
    public bool EaiTask { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("historyTask")]
    [JsonPropertyName("historyTask")]
    public bool HistoryTask { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("root")]
    [JsonPropertyName("root")]
    public bool Root { get; set; }
}

