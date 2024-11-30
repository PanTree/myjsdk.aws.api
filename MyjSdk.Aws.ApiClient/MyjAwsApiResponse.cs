using System.Text.Json.Serialization;
using MyjSdk.FlurlHttpClient;
using Newtonsoft.Json;

namespace MyjSdk.Aws.ApiClient;

public class MyjAwsApiResponse : ICommonResponse
{
    /// <summary>
    ///     获取原始的 HTTP 响应状态码。
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public int RawStatus
    {
        get => ((ICommonResponse)this).RawStatus;
        internal set => ((ICommonResponse)this).RawStatus = value;
    }

    /// <summary>
    ///     获取原始的 HTTP 响应表头集合。
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public IDictionary<string, string> RawHeaders
    {
        get => ((ICommonResponse)this).RawHeaders;
        internal set => ((ICommonResponse)this).RawHeaders = value;
    }

    /// <summary>
    ///     获取原始的 HTTP 响应正文。
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public byte[] RawBytes
    {
        get => ((ICommonResponse)this).RawBytes;
        internal set => ((ICommonResponse)this).RawBytes = value;
    }

    /// <summary>
    ///     获取 API 返回的错误码。
    /// </summary>
    [JsonProperty("errorCode")]
    [JsonPropertyName("errorCode")]
    public virtual string? ErrorCode { get; set; }

    /// <summary>
    ///     获取 API 返回的错误描述。
    /// </summary>
    [JsonProperty("msg")]
    [JsonPropertyName("msg")]
    public virtual string? ErrorMessage { get; set; }
    /// <summary>
    ///     获取 API 返回的错误描述。
    /// </summary>
    [JsonProperty("result")]
    [JsonPropertyName("result")]
    public virtual string? Result { get; set; }

    /// <summary>
    /// </summary>
    int ICommonResponse.RawStatus { get; set; }

    /// <summary>
    /// </summary>
    IDictionary<string, string> ICommonResponse.RawHeaders { get; set; } = default!;

    /// <summary>
    /// </summary>
    byte[] ICommonResponse.RawBytes { get; set; } = default!;

    public bool IsSuccessful()
    {
        return RawStatus == 200 && string.IsNullOrEmpty(ErrorCode);
    }
}

public class MyjAwsApiResponse<T> : MyjAwsApiResponse where T : class
{
    [JsonProperty("data")]
    [JsonPropertyName("data")]
    public virtual T? Data { get; set; }
}
public class MyjAwsApiStructResponse<T> : MyjAwsApiResponse where T : struct
{
    [JsonProperty("data")]
    [JsonPropertyName("data")]
    public virtual T? Data { get; set; }
}

