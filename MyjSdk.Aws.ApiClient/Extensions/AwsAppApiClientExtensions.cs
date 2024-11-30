using MyjSdk.Aws.ApiClient.Model;

namespace MyjSdk.Aws.ApiClient.Extensions;

/// <summary>
///     APP应用管理
/// </summary>
public static class AwsAppApiClientExtensions
{
    /// <summary>
    ///     获得app在当前AWS节点实例(JVM)的上下文对象
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MyjAwsApiResponse<string>> ExecuteAppUserGetAsync(this MyjAwsApiClient client,
        AppUserGetRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        ArgumentNullException.ThrowIfNull(request);

        var paramsMap = new Dictionary<string, string?>
        {
            { "cmd", "com.awspaas.user.apps.app20221017162312.getSid" },
            //{ "access_key", client.Credentials.AccessKey },
            { "userId", request.UserId }
        };
        using var httpContent = new FormUrlEncodedContent(paramsMap);


        var fRequest = client
                .CreateRequest(request, HttpMethod.Post, "portal", "r", "jd")
            /*.WithSettings(s =>
            {
                s.JsonSerializer = new FlurlNewtonsoftJsonSerializer();
            })*/
            ;

        return await client.SendRequestAsync<MyjAwsApiResponse<string>>(fRequest, httpContent, cancellationToken);
    }
}