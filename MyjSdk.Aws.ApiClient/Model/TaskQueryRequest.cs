using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

public class TaskQueryRequest : MyjAwsApiRequest
{
    /// <summary>
    ///     taskInstIds 一组任务实例ID
    /// </summary>
    [JsonProperty("ids")]
    [JsonPropertyName("ids")]
    public List<string>? Ids { get; set; }

    [JsonProperty("partition")]
    [JsonPropertyName("partition")]
    public List<string>? Partition { get; set; }

    /// <summary>
    ///     流程组Id
    /// </summary>
    [JsonProperty("processGroupId")]
    [JsonPropertyName("processGroupId")]
    public string? ProcessGroupId { get; set; }

    /// <summary>
    ///     多个流程组Id
    /// </summary>
    [JsonProperty("processGroupIds")]
    [JsonPropertyName("processGroupIds")]
    public List<string>? ProcessGroupIds { get; set; }

    /// <summary>
    ///     父任务ID
    /// </summary>
    [JsonProperty("parentTaskInstId")]
    [JsonPropertyName("parentTaskInstId")]
    public string? ParentTaskInstId { get; set; }

    /// <summary>
    ///     范围ID，流程首个节点实例化范围Id为-1
    /// </summary>
    [JsonProperty("scopeId")]
    [JsonPropertyName("scopeId")]
    public string? ScopeId { get; set; }

    /// <summary>
    ///     一个BPMN节点定义ID
    /// </summary>
    [JsonProperty("activityDefId")]
    [JsonPropertyName("activityDefId")]
    public string? ActivityDefId { get; set; }

    /// <summary>
    ///     流程实例ID
    /// </summary>
    [JsonProperty("processInstId")]
    [JsonPropertyName("processInstId")]
    public string? ProcessInstId { get; set; }

    /// <summary>
    ///     外部业务系统主键标识
    /// </summary>
    [JsonProperty("processBusinessKey")]
    [JsonPropertyName("processBusinessKey")]
    public string? ProcessBusinessKey { get; set; }

    /// <summary>
    ///     流程模型ID
    /// </summary>
    [JsonProperty("processDefId")]
    [JsonPropertyName("processDefId")]
    public string? ProcessDefId { get; set; }

    /// <summary>
    ///     流程主版本ID
    /// </summary>
    [JsonProperty("processDefVerId")]
    [JsonPropertyName("processDefVerId")]
    public string? ProcessDefVerId { get; set; }

    /// <summary>
    ///     任务标题等于特定内容的任务
    ///     <para>任务标题</para>
    /// </summary>
    [JsonProperty("title")]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    ///     任务标题包含特定内容的任务
    ///     <para>任务标题，注意应包含通配符，如后缀%</para>
    /// </summary>
    [JsonProperty("titleLike")]
    [JsonPropertyName("titleLike")]
    public string? TitleLike { get; set; }

    /// <summary>
    ///     任务类型
    ///     <para>BPMN元素或扩展，见TaskRuntimeConst.ACTIVITY_TYPE</para>
    /// </summary>
    [JsonProperty("activityType")]
    [JsonPropertyName("activityType")]
    public string? ActivityType { get; set; }

    /// <summary>
    ///     人工任务
    /// </summary>
    [JsonProperty("userTask")]
    [JsonPropertyName("userTask")]
    public bool? UserTask { get; set; }

    /// <summary>
    ///     非人工任务
    /// </summary>
    [JsonProperty("nonUserTask")]
    [JsonPropertyName("nonUserTask")]
    public bool? NonUserTask { get; set; }

    /// <summary>
    ///     EAI类外部任务，这类任务不由工作流引擎驱动
    /// </summary>
    [JsonProperty("eaiTask")]
    [JsonPropertyName("eaiTask")]
    public bool? EaiTask { get; set; }

    /// <summary>
    ///     正常活动的任务
    /// </summary>
    [JsonProperty("activeTask")]
    [JsonPropertyName("activeTask")]
    public bool? ActiveTask { get; set; }

    /// <summary>
    ///     已暂时挂起的任务
    /// </summary>
    [JsonProperty("suspendedTask")]
    [JsonPropertyName("suspendedTask")]
    public bool? SuspendedTask { get; set; }

    /// <summary>
    ///     已发生错误的任务
    /// </summary>
    [JsonProperty("erroredTask")]
    [JsonPropertyName("erroredTask")]
    public bool? ErroredTask { get; set; }

    /// <summary>
    ///     待办工作类任务（正常待办、加签类待办等）
    /// </summary>
    [JsonProperty("userTaskOfWorking")]
    [JsonPropertyName("userTaskOfWorking")]
    public bool? UserTaskOfWorking { get; set; }

    /// <summary>
    ///     通知类待办任务（传阅、系统通知）
    /// </summary>
    [JsonProperty("userTaskOfNotification")]
    [JsonPropertyName("userTaskOfNotification")]
    public bool? UserTaskOfNotification { get; set; }

    /// <summary>
    ///     指定的任务类型，如传阅、加签、待办
    ///     <para>state 状态值，参见UserTaskRuntimeConst.STATE_TYPE_*</para>
    /// </summary>
    [JsonProperty("taskState")]
    [JsonPropertyName("taskState")]
    public int? TaskState { get; set; }

    /// <summary>
    ///     uid 一个合法的AWS账户名
    ///     <para> 执行人的任务，列出的任务范围由该账户执行</para>
    /// </summary>
    [JsonProperty("target")]
    [JsonPropertyName("target")]
    public string? Target { get; set; }

    /// <summary>
    ///     uid AWS账户或外部系统名称
    ///     <para>创建人的任务，列出的任务由该账户创建。如果是EAI外部任务，该值为EAI任务的系统简称</para>
    /// </summary>
    [JsonProperty("owner")]
    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    /// <summary>
    ///     departmentId 部门ID
    ///     <para>由指定部门的人员认领的任务</para>
    /// </summary>
    [JsonProperty("claimToDepartment")]
    [JsonPropertyName("claimToDepartment")]
    public string? ClaimToDepartment { get; set; }

    /// <summary>
    ///     roleId 角色ID
    ///     <para>由指定角色的人员认领的任务</para>
    /// </summary>
    [JsonProperty("claimToRole")]
    [JsonPropertyName("claimToRole")]
    public string? ClaimToRole { get; set; }

    /// <summary>
    ///     teamId 小组ID
    ///     <para>由指定小组的人员认领的任务</para>
    /// </summary>
    [JsonProperty("claimToTeam")]
    [JsonPropertyName("claimToTeam")]
    public string? ClaimToTeam { get; set; }

    /// <summary>
    ///     任务没有参与者，暂时认领给管理员的异常任务
    /// </summary>
    [JsonProperty("claimToAdministrator")]
    [JsonPropertyName("claimToAdministrator")]
    public bool? ClaimToAdministrator { get; set; }

    /// <summary>
    ///     优先级
    ///     <para>任务优先级（0：低；1：无；2：中；3：高）</para>
    /// </summary>
    [JsonProperty("priority")]
    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    /// <summary>
    ///     在指定日期之前创建的任务
    ///     <para>date 任务创建日期时间，需要精确到小时分，含该日期</para>
    /// </summary>
    [JsonProperty("BeginBefore")]
    [JsonPropertyName("BeginBefore")]
    public string? BeginBefore { get; set; }

    /// <summary>
    ///     在指定日期之后创建的任务
    ///     <para>date 任务创建日期时间，需要精确到小时分，含该日期</para>
    /// </summary>
    [JsonProperty("beginAfter")]
    [JsonPropertyName("beginAfter")]
    public string? BeginAfter { get; set; }

    /// <summary>
    ///     是否已读取
    ///     <para>已读或未读的任务</para>
    /// </summary>
    [JsonProperty("read")]
    [JsonPropertyName("read")]
    public bool? Read { get; set; }

    /// <summary>
    ///     被超时策略监控的任务
    /// </summary>
    [JsonProperty("monitorTask")]
    [JsonPropertyName("monitorTask")]
    public bool? MonitorTask { get; set; }

    /// <summary>
    ///     异步执行的任务
    /// </summary>
    [JsonProperty("asyncTask")]
    [JsonPropertyName("asyncTask")]
    public bool? AsyncTask { get; set; }

    /// <summary>
    ///     AWS节点标识
    ///     <para>该任务被指定的AWS服务节点创建</para>
    /// </summary>
    [JsonProperty("beginEngineNodeTask")]
    [JsonPropertyName("beginEngineNodeTask")]
    public string? BeginEngineNodeTask { get; set; }


    /// <summary>
    ///     业务域ID，该实例属于某类业务域，如电信的OSS、BSS、MSS
    /// </summary>
    [JsonProperty("IOBD")]
    [JsonPropertyName("IOBD")]
    public string? Iobd { get; set; } = string.Empty;

    /// <summary>
    ///     组织区域ID，该实例属于某组织区域的业务数据，如中国大陆、东南亚、北美
    /// </summary>
    [JsonProperty("IOR")]
    [JsonPropertyName("IOR")]
    public string? Ior { get; set; } = string.Empty;

    /// <summary>
    ///     系统ID，该实例属于某类系统依赖的流程，如营销系统、生产系统、OA系统
    /// </summary>
    [JsonProperty("IOS")]
    [JsonPropertyName("IOS")]
    public string? Ios { get; set; } = string.Empty;

    /// <summary>
    ///     自定义ID，这是一个开放的自定义项，可根据管理需要定义规则名称和规则项
    /// </summary>
    [JsonProperty("IOC")]
    [JsonPropertyName("IOC")]
    public string? Ioc { get; set; } = string.Empty;

    /// <summary>
    ///    一个合法的AWS账户名
    /// <para>查询结果合并从公共池待认领的任务，该特性受bpmn.properties文件ENGINE_CLAIM_SUPPORT配置的影响</para>
    ///  <para>引擎支持的公共池任务类型包括团队、角色和部门</para>
    /// </summary>
    [JsonProperty("supportClaimTask")]
    [JsonPropertyName("supportClaimTask")]
    public string? SupportClaimTask { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("supportDelegateTask")]
    [JsonPropertyName("supportDelegateTask")]
    public bool? SupportDelegateTask { get; set; }

    [JsonProperty("orderByBeginTimeASC")]
    [JsonPropertyName("orderByBeginTimeASC")]
    public bool? OrderByBeginTimeAsc { get; set; }

    [JsonProperty("orderByPriorityASC")]
    [JsonPropertyName("orderByPriorityASC")]
    public bool? OrderByPriorityAsc { get; set; }

    [JsonProperty("orderByTitleASC")]
    [JsonPropertyName("orderByTitleASC")]
    public bool? OrderByTitleAsc { get; set; }

}