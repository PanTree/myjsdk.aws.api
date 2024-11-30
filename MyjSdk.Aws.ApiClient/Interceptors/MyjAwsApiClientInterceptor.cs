using System.Text;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using MyjSdk.Aws.ApiClient.Utilities;
using MyjSdk.FlurlHttpClient.Constants;
using MyjSdk.FlurlHttpClient.Interception;

namespace MyjSdk.Aws.ApiClient.Interceptors;

public class MyjAwsApiClientInterceptor : FlurlHttpCallInterceptor
{
    private readonly string _agencyApiSecret;
    private readonly string _agencyKey;
    private readonly AuthorizationType _authorizationType;
    private readonly ILogger? _logger;

    public MyjAwsApiClientInterceptor(string agencyKey, string agencyApiSecret, ILogger? logger,
        AuthorizationType authType = AuthorizationType.Signature)
    {
        _agencyKey = agencyKey;
        _agencyApiSecret = agencyApiSecret;
        _logger = logger;
        _authorizationType = authType;
    }

    public override async Task BeforeCallAsync(FlurlCall flurlCall)
    {
        var formData = new Dictionary<string, string>();
        if (flurlCall.HttpRequestMessage.Content != null)
        {
            var requestContent = await flurlCall.HttpRequestMessage.Content.ReadAsStringAsync();

            foreach (var pair in requestContent.Split('&'))
            {
                var keyValue = pair.Split('=');
                formData.Add(Uri.UnescapeDataString(keyValue[0]), Uri.UnescapeDataString(keyValue[1]));
            }

            formData.TryAdd("access_key", _agencyKey);
            formData.TryAdd("timestamp", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
            formData.TryAdd("sig_method", "HmacMD5");
            formData.TryAdd("format", "json");
        }

        switch (_authorizationType)
        {
            case AuthorizationType.Signature:
            {
                var sign = AwsSignature.MakeSign(formData!, _agencyApiSecret);
                formData.Add("sig", sign);
                var httpContent = new FormUrlEncodedContent(formData);
                flurlCall.HttpRequestMessage.Content = httpContent;
                break;
            }
            case AuthorizationType.BasicAuth:
                flurlCall.Client.WithBasicAuth(_agencyKey, _agencyApiSecret);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        var stringBuilder = new StringBuilder();
        var body = "";
        if (flurlCall.HttpRequestMessage.Content != null)
            body = await flurlCall.HttpRequestMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        stringBuilder.AppendLine($"{flurlCall.HttpRequestMessage}");
        stringBuilder.AppendLine(
            $"clientHead:{System.Text.Json.JsonSerializer.Serialize(flurlCall.Client.Headers.GroupBy(e => e.Name)
                .ToDictionary(
                    k => k.Key,
                    v => string.Join(",", v.Select(e => e.Value)),
                    StringComparer.OrdinalIgnoreCase
                ))}");
        stringBuilder.AppendLine($"body:{body}");
        _logger?.LogInformation(stringBuilder.ToString());
    }

    public override async Task AfterCallAsync(FlurlCall flurlCall)
    {
        var contentType = flurlCall.Response?.Headers?.GetAll(HttpHeaders.ContentType).FirstOrDefault();
        // var charset = MediaTypeHeaderValue.TryParse(contentType, out var mediaType) ? mediaType.CharSet : null;
        var content = flurlCall.HttpResponseMessage?.Content;
        if (content != null)
        {
            var body =await content.ReadAsStringAsync().ConfigureAwait(false);
            _logger?.LogInformation($"{contentType ?? ""};{body}");
        }
    }
}