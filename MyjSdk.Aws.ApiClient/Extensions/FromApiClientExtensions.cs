using MyjSdk.Aws.ApiClient.Model;

namespace MyjSdk.Aws.ApiClient.Extensions;

public static class FromApiClientExtensions
{
    /// <summary>
    ///     获取流程跟踪URL
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<string>> ExecuteFormTrackUrlAsync(
        this MyjAwsApiClient client,
        FormTrackUrlRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "form.track.url" },
            { "bpmPortalHost", request.BpmPortalHost },
            { "sid", request.Sid },
            { "processInstId", request.ProcessInstId },
            { "supportCanvas", request.SupportCanvas.ToString() },
            { "formInfo", request.FormInfo }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);

        var fRequest = client.CreateRequest(request, HttpMethod.Post, "portal", "api")
            ;
        

        return await client.SendRequestAsync<MyjAwsApiResponse<string>>(fRequest, httpContent,
            cancellationToken);
    }
}