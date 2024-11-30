using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyjSdk.Aws.ApiClient.Model;

public class TaskActivityResponse
{
    [JsonProperty("taskList")]
    [JsonPropertyName("taskList")]
    public List<TaskItem> TaskList { get; set; } = new();
}

public class TaskItem
{
    [JsonProperty("activityId")]
    [JsonPropertyName("activityId")]
    public string ActivityId { get; set; } = string.Empty;

    [JsonProperty("activityType")]
    [JsonPropertyName("activityType")]
    public string ActivityType { get; set; } = string.Empty;

    [JsonProperty("controlState")]
    [JsonPropertyName("controlState")]
    public string ControlState { get; set; } = string.Empty;


    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("startTime")]
    [JsonPropertyName("startTime")]
    public string StartTime { get; set; } = string.Empty;

    [JsonProperty("title")]
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("endTime")]
    [JsonPropertyName("endTime")]
    public string EndTime { get; set; } = string.Empty;
}