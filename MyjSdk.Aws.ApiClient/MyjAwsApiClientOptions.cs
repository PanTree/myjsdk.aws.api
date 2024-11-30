namespace MyjSdk.Aws.ApiClient;

public class MyjAwsApiClientOptions
{
    /// <summary>
    ///     获取或设置请求超时时间（单位：毫秒）。
    ///     <para>默认值：30000</para>
    /// </summary>
    public int Timeout { get; set; } = 30 * 1000;

    /// <summary>
    ///     获取或设置凭证key。
    /// </summary>
    public string AccessKey { get; set; } = default!;

    /// <summary>
    ///     获取或设置凭证key AppSecret。
    /// </summary>
    public string AppSecret { get; set; } = default!;

    public string Endpoint { get; set; } = string.Empty;

    public string DefaultUId { get; set; } = "system";
}

