using Flurl.Http.Configuration;

namespace MyjSdk.FlurlHttpClient;

public sealed class CommonClientSettings
{
    internal CommonClientSettings(FlurlHttpSettings flurlClientSettings)
    {
        ConnectionRequestTimeout = flurlClientSettings.Timeout;
        HttpVersion = flurlClientSettings.HttpVersion;
        JsonSerializer = flurlClientSettings.JsonSerializer;
        UrlEncodedSerializer = flurlClientSettings.UrlEncodedSerializer;
        AllowedHttpStatusRange = flurlClientSettings.AllowedHttpStatusRange;
    }

    /// <summary>
    /// </summary>
    public TimeSpan? ConnectionRequestTimeout { get; set; }

    /// <summary>
    /// </summary>
    public string HttpVersion { get; set; }

    /// <summary>
    /// </summary>
    public ISerializer JsonSerializer { get; set; } = default!;

    /// <summary>
    /// </summary>
    public ISerializer UrlEncodedSerializer { get; set; } = default!;

    public string AllowedHttpStatusRange { get; set; } = default!;


    /// <summary>
    /// </summary>
    public bool ThrowOnSerializationError { get; set; } = true;
}