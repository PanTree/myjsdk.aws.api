using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using MyjSdk.Aws.ApiClient.Extensions;
using MyjSdk.Aws.ApiClient.Model;
using Volo.Abp.Testing;
using Xunit;
using Xunit.Abstractions;

namespace MyjSdk.Aws.ApiClient.Test.Test;

public sealed class AppApiClientExtensionsTest : AbpIntegratedTest<MyjAssApiClientTestModule>
{
    private readonly IFlurlClientCache _clientCache;
    private readonly MyjAwsApiClientOptions _option;
    private readonly ITestOutputHelper _testOutput;


    public AppApiClientExtensionsTest(ITestOutputHelper testOutputHelper)
    {
        _option = GetRequiredService<IOptions<MyjAwsApiClientOptions>>().Value;
        _clientCache = GetRequiredService<IFlurlClientCache>();
        _testOutput = testOutputHelper;
    }

    [Fact]
    public async Task AppUserGetTest()
    {
        var client = new MyjAwsApiClient(_option, _clientCache);

        var res = await client.ExecuteAppUserGetAsync(new AppUserGetRequest
        {
            UserId = "102864"
        });

        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);
    }
}