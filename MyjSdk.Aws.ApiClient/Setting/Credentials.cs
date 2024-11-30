namespace MyjSdk.Aws.ApiClient.Setting;

/// <summary>
///     凭证
/// </summary>
public class Credentials
{
    internal Credentials(MyjAwsApiClientOptions options)
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        AccessKey = options.AccessKey;
        AppSecret = options.AppSecret;
    }

    /// <summary>
    ///     获取或设置凭证key。
    /// </summary>
    public string AccessKey { get; }

    /// <summary>
    ///     获取或设置凭证key AppSecret。
    /// </summary>
    public string AppSecret { get; }
}

