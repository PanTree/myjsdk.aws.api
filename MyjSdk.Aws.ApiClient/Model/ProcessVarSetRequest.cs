using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyjSdk.Aws.ApiClient.Model
{
    public class ProcessVarSetRequest : MyjAwsApiRequest,
        IInferable<ProcessVarSetRequest, MyjAwsApiResponse>
    {
        /// <summary>
        ///     流程实例ID
        /// </summary>
        [JsonProperty("processInstId")]
        [JsonPropertyName("processInstId")]
        public virtual string ProcessInstId { get; set; } = string.Empty;

        /// <summary>
        ///     变量名
        /// </summary>
        [JsonProperty("vars")]
        [JsonPropertyName("vars")]
        public virtual Dictionary<string, object> Vars { get; set; } = new();
    }
}
