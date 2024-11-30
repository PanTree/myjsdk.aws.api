using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

public class AppUserGetRequest : MyjAwsApiRequest
{
    /// <summary>
    /// </summary>
    [JsonProperty("userId")]
    [JsonPropertyName("userId")]
    public virtual string UserId { get; set; } = string.Empty;


}