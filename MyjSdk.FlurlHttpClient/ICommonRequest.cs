using Newtonsoft.Json;

namespace MyjSdk.FlurlHttpClient;

public interface ICommonRequest
{
    /// <summary>
    ///     获取或设置请求超时时间（单位：毫秒）。
    /// </summary>
    [JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public int? Timeout { get; set; }
}