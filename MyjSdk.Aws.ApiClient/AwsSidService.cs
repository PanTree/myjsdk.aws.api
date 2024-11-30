using Flurl.Http.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyjSdk.Aws.ApiClient.Extensions;
using MyjSdk.Aws.ApiClient.Model;
using Volo.Abp;
using Volo.Abp.Caching;

namespace MyjSdk.Aws.ApiClient;

public class AwsSidService : IAwsSidService
{
    private readonly IFlurlClientCache _clientCache;
    private readonly ILogger _logger;
    private readonly MyjAwsApiClientOptions _option;
    private readonly IDistributedCache<string> _sidCache;

    public AwsSidService(IDistributedCache<string> sidCache,
        IFlurlClientCache commonClient,
        IOptions<MyjAwsApiClientOptions> option,
        ILogger<AwsSidService> logger
    )
    {
        _sidCache = sidCache;
        _clientCache = commonClient;
        _option = option.Value;
        _logger = logger;
    }

    public async Task<string?> GetAwsSidAsync(string uid)
    {
        var sid = await _sidCache.GetOrAddAsync(uid, async () =>
        {
            var client = new MyjAwsApiClient(_option, _clientCache, _logger);

            var resp = await client.ExecuteAppUserGetAsync(new AppUserGetRequest
            {
                UserId = uid
            });
            if (!resp.IsSuccessful())
                throw new BusinessException("403", $"获取Sid失败;{resp.ErrorCode}-{resp.ErrorMessage}");
            return resp.Data ?? "";
        }, () => new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(100)
        });
        return sid;
    }
}