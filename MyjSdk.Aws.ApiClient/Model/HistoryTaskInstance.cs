

using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyjSdk.Aws.ApiClient.Model
{
    public class HistoryTaskInstance : TaskInstanceResponse
    {
        /// <summary>
        ///     是否允许收回已办的任务
        /// </summary>
        [JsonProperty("isUndo")]
        [JsonPropertyName("isUndo")]
        public bool IsUndo { get; set; }
        /// <summary>
        /// 任务结束时间
        /// </summary>
        [JsonProperty("endTime")]
        [JsonPropertyName("endTime")]
        private long EndTime { get; set; }

        /// <summary>
        /// 任务结束时AWS服务器处理节点，集群时配置的ip:port
        /// </summary>
        [JsonProperty("endEngineNode")]
        [JsonPropertyName("endEngineNode")]
        private string EndEngineNode { get; set; } = string.Empty;

        /// <summary>
        /// 任务执行消耗的时间
        /// </summary>
        [JsonProperty("executeCostTime")]
        [JsonPropertyName("executeCostTime")]
        private long ExecuteCostTime { get; set; }

        /// <summary>
        /// 任务超时时间（KPI）
        /// </summary>
        [JsonProperty("executeExpireTime")]
        [JsonPropertyName("executeExpireTime")]
        private long ExecuteExpireTime { get; set; }
    }
}
