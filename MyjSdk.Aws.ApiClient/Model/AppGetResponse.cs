using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

public class AppGetResponse
{
    [JsonProperty("allowUpgradeByStore")]
    [JsonPropertyName("allowUpgradeByStore")]
    public bool AllowUpgradeByStore { get; set; }

    [JsonProperty("buildNo")]
    [JsonPropertyName("buildNo")]
    public int BuildNo { get; set; }
}

