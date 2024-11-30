using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using MyjSdk.Aws.ApiClient.Extensions;
using MyjSdk.Aws.ApiClient.Model;
using Volo.Abp.Testing;
using Xunit;
using Xunit.Abstractions;

namespace MyjSdk.Aws.ApiClient.Test.Test;

public sealed class FormTrackUrlTest : AbpIntegratedTest<MyjAssApiClientTestModule>
{
    private readonly IFlurlClientCache _clientCache;
    private readonly MyjAwsApiClientOptions _option;
    private readonly IAwsSidService _sidService;
    private readonly ITestOutputHelper _testOutput;

    public FormTrackUrlTest(ITestOutputHelper testOutputHelper)
    {
        _option = GetRequiredService<IOptions<MyjAwsApiClientOptions>>().Value;
        _sidService = GetRequiredService<IAwsSidService>();
        _clientCache = GetRequiredService<IFlurlClientCache>();
        _testOutput = testOutputHelper;
    }

    [Fact]
    public async Task AppFormTrackUrlTest()
    {
        var sid = await _sidService.GetAwsSidAsync("PD0001");
        var client = new MyjAwsApiClient(_option, _clientCache);
        var res = await client.ExecuteFormTrackUrlAsync(new FormTrackUrlRequest
        {
            BpmPortalHost = "./w",
            Sid = sid,
            ProcessInstId = "227c5709-182c-4c67-98bf-ea306ac0adea"
        });

        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);
    }
}