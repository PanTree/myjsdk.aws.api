using Newtonsoft.Json;

namespace MyjSdk.FlurlHttpClient;

/// <summary>
///     响应接口
/// </summary>
public interface ICommonResponse
{
    /// <summary>
    ///     获取原始的 HTTP 响应状态码。
    /// </summary>
    [JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public int RawStatus { get; set; }

    /// <summary>
    ///     获取原始的 HTTP 响应表头集合。
    /// </summary>
    [JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public IDictionary<string, string> RawHeaders { get; set; }

    /// <summary>
    ///     获取原始的 HTTP 响应正文。
    /// </summary>
    [JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public byte[] RawBytes { get; set; }

    /// <summary>
    ///     获取一个值，该值指示调用 API 是否成功。
    /// </summary>
    /// <returns></returns>
    bool IsSuccessful();
}