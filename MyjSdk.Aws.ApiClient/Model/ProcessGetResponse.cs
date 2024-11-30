using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyjSdk.Aws.ApiClient.Model
{
    public class ProcessGetResponse
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("quickStart")]
        [JsonPropertyName("quickStart")]
        public bool QuickStart { get; set; }
        /// <summary>
        /// 流程管理者
        /// </summary>
        [JsonProperty("processAdministrator")]
        [JsonPropertyName("processAdministrator")]
        public string ProcessAdministrator { get; set; } = string.Empty;

        [JsonProperty("securityLayer")]
        [JsonPropertyName("securityLayer")]
        public bool SecurityLayer { get; set; }

        [JsonProperty("nameI18N")]
        [JsonPropertyName("nameI18N")]
        public string NameI18N { get; set; } = string.Empty;

        [JsonProperty("cancelTask")]
        [JsonPropertyName("cancelTask")]
        public bool CancelTask { get; set; }

        [JsonProperty("wariningTimeDurationText")]
        [JsonPropertyName("wariningTimeDurationText")]
        public string WariningTimeDurationText { get; set; } = string.Empty;

        [JsonProperty("formSummary")]
        [JsonPropertyName("formSummary")]
        public bool FormSummary { get; set; }

        [JsonProperty("appId")]
        [JsonPropertyName("appId")]
        public string AppId { get; set; } = string.Empty;

        [JsonProperty("versionNo")]
        [JsonPropertyName("versionNo")]
        public int VersionNo { get; set; }

        [JsonProperty("matrixDistributed")]
        [JsonPropertyName("matrixDistributed")]
        public bool MatrixDistributed { get; set; }

        [JsonProperty("processGroupNameI18N")]
        [JsonPropertyName("processGroupNameI18N")]
        public string ProcessGroupNameI18N { get; set; } = string.Empty;

        [JsonProperty("historyMaxVersion")]
        [JsonPropertyName("historyMaxVersion")]
        public int HistoryMaxVersion { get; set; }

        [JsonProperty("initSecurityLayer")]
        [JsonPropertyName("initSecurityLayer")]
        public int InitSecurityLayer { get; set; }

        [JsonProperty("timeDuration")]
        [JsonPropertyName("timeDuration")]
        public int TimeDuration { get; set; }

        [JsonProperty("tplLockedInfo")]
        [JsonPropertyName("tplLockedInfo")]
        public string TplLockedInfo { get; set; } = string.Empty;

        [JsonProperty("versionId")]
        [JsonPropertyName("versionId")]
        public string VersionId { get; set; } = string.Empty;

        [JsonProperty("cancelProcessExclusiveRule")]
        [JsonPropertyName("cancelProcessExclusiveRule")]
        public string CancelProcessExclusiveRule { get; set; } = string.Empty;

        [JsonProperty("draftRemove")]
        [JsonPropertyName("draftRemove")]
        public bool DraftRemove { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("mapRoleSelectAtStart")]
        [JsonPropertyName("mapRoleSelectAtStart")]
        public bool MapRoleSelectAtStart { get; set; }

        [JsonProperty("leanStandard")]
        [JsonPropertyName("leanStandard")]
        public double LeanStandard { get; set; }

        [JsonProperty("trackDiagramType")]
        [JsonPropertyName("trackDiagramType")]
        public string TrackDiagramType { get; set; } = string.Empty;

        [JsonProperty("wariningTimeDuration")]
        [JsonPropertyName("wariningTimeDuration")]
        public int WariningTimeDuration { get; set; }

        [JsonProperty("processLevelType")]
        [JsonPropertyName("processLevelType")]
        public int ProcessLevelType { get; set; }

        [JsonProperty("engineType")]
        [JsonPropertyName("engineType")]
        public int EngineType { get; set; }

        [JsonProperty("transferPriority")]
        [JsonPropertyName("transferPriority")]
        public bool TransferPriority { get; set; }

        [JsonProperty("processGroupName")]
        [JsonPropertyName("processGroupName")]
        public string ProcessGroupName { get; set; } = string.Empty;

        [JsonProperty("categoryName")]
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; } = string.Empty;

        [JsonProperty("versionStatus")]
        [JsonPropertyName("versionStatus")]
        public int VersionStatus { get; set; }

        [JsonProperty("resetLostHistory")]
        [JsonPropertyName("resetLostHistory")]
        public bool ResetLostHistory { get; set; }

        [JsonProperty("managed")]
        [JsonPropertyName("managed")]
        public bool Managed { get; set; }

        [JsonProperty("trackForm")]
        [JsonPropertyName("trackForm")]
        public bool TrackForm { get; set; }

        [JsonProperty("worklistPopMini")]
        [JsonPropertyName("worklistPopMini")]
        public bool WorklistPopMini { get; set; }

        [JsonProperty("processType")]
        [JsonPropertyName("processType")]
        public string ProcessType { get; set; } = string.Empty;

        [JsonProperty("class")]
        [JsonPropertyName("class")]
        public string Class { get; set; } = string.Empty;

        [JsonProperty("ignoreMapRoleSelect")]
        [JsonPropertyName("ignoreMapRoleSelect")]
        public bool IgnoreMapRoleSelect { get; set; }

        [JsonProperty("processGroupId")]
        [JsonPropertyName("processGroupId")]
        public string ProcessGroupId { get; set; } = string.Empty;

        [JsonProperty("mobileStart")]
        [JsonPropertyName("mobileStart")]
        public bool MobileStart { get; set; }

        [JsonProperty("updateUser")]
        [JsonPropertyName("updateUser")]
        public string UpdateUser { get; set; } = string.Empty;

        [JsonProperty("updateTime")]
        [JsonPropertyName("updateTime")]
        public long UpdateTime { get; set; }

        [JsonProperty("executable")]
        [JsonPropertyName("executable")]
        public bool Executable { get; set; }

        [JsonProperty("notifyConfig")]
        [JsonPropertyName("notifyConfig")]
        public string NotifyConfig { get; set; } = string.Empty;

        [JsonPropertyName("tpl")]
        public bool Tpl { get; set; }

        [JsonPropertyName("createTime")]
        public long CreateTime { get; set; }

        [JsonPropertyName("accessSecurityType")]
        public int AccessSecurityType { get; set; }

        [JsonPropertyName("closed")]
        public bool Closed { get; set; }

        [JsonPropertyName("createUser")]
        public string CreateUser { get; set; } = string.Empty;

        [JsonPropertyName("toString")]
        public string CtoolToString { get; set; }=string.Empty;

        [JsonPropertyName("dataShare")]
        public bool DataShare { get; set; }

        [JsonPropertyName("cancelProcess")]
        public bool CancelProcess { get; set; }

    }
}
