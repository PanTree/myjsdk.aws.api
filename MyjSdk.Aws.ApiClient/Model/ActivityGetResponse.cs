using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient.Model;

public class ActivityGetResponse
{
    [JsonProperty("activityList")]
    [JsonPropertyName("activityList")]
    public List<ActivityItem> ActivityList { get; set; } = new();

    [JsonProperty("ext")]
    [JsonPropertyName("ext")]
    public List<ExpansionItem> Expansion { get; set; } = new();

}


public class ActivityItem
{
    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("no")]
    [JsonPropertyName("no")]
    public int No { get; set; } 

    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("type")]
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;


    [JsonProperty("customId")]
    [JsonPropertyName("customId")]
    public string CustomId { get; set; } = string.Empty;

}

public class ExpansionItem
{
    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("extendProperty")]
    [JsonPropertyName("extendProperty")]
    public List<ExpansionProperty>? ExtendProperty { get; set; }
}

public class ExpansionProperty
{
    [JsonProperty("key")]
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    [JsonProperty("value")]
    [JsonPropertyName("value")]
    public string? Value { get; set; } = string.Empty;

    [JsonProperty("desc")]
    [JsonPropertyName("desc")]
    public string? Description { get; set; } = string.Empty;

}