using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using MyjSdk.Aws.ApiClient.Extensions;
using MyjSdk.Aws.ApiClient.Model;
using Volo.Abp.Testing;
using Xunit;
using Xunit.Abstractions;

namespace MyjSdk.Aws.ApiClient.Test.Test;

public sealed class ProcessApiExtensionTest : AbpIntegratedTest<MyjAssApiClientTestModule>
{
    private readonly MyjAwsApiClient _client;
    private readonly ITestOutputHelper _testOutput;


    public ProcessApiExtensionTest(ITestOutputHelper testOutputHelper)
    {
        var option = GetRequiredService<IOptions<MyjAwsApiClientOptions>>().Value;

        var clientCache = GetRequiredService<IFlurlClientCache>();
        _testOutput = testOutputHelper;
        _client = new MyjAwsApiClient(option, clientCache);
    }

    /// <summary>
    ///     流程创建
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessCreateTest()
    {
        var resp = await _client.ExecutePrecessCreateAsync(new ProcessCreateRequest
        {
            ProcessDefId = "obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd",
            Uid = "PD0001",
            Title = DateTimeOffset.Now.ToUnixTimeSeconds().ToString(),
            ProcessBusinessKey = "粤12345_E2402290001",
            Vars = new
                Dictionary<string, object>
                {
                    { "test", "1" }
                }
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.NotNull(resp.Data);
        /*{"id":"782c8a76-6894-4a00-9bdb-567e90b27c5f","processBusinessKey":"2382c7dbdca8420ab99427b286f5f174","processGroupId":"obj_aabb852ed8144da99d98ff5e01d96212","title":"测试","controlState":"active","processDefId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processDefVerId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","createTime":1705474059674,"startTime":null,"endTime":null,"startActivityId":"","startTaskInstId":"","endActivityId":"","remark":"","isProcess":true,"isStart":false,"isEnd":false,"isAsync":false,"isException":false,"isOvertime":false,"subProcess":false,"existSubProcess":false,"createUser":"PD0001","createUserDeptId":"1004000000000010009","createUserRoleId":"e5591c54-2af8-4622-93ec-d803594d1e51","createUserLocation":"美宜佳控股有限公司//数据IT体系/数字产品运营中心/门店数字产品部/","createUserOrgId":"8911e732-b42a-4556-853f-ad32761bcbee","securityLayer":0,"executeCostTime":0,"executeExpireTime":0,"parentProcessInstId":"","parentTaskInstId":"","processProfileId":"","subInstType":0,"IOBD":"","IOR":"","IOS":"","IOC":"","remindTimes":0}*/
    }

    /// <summary>
    ///     通过id启动流程
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessStartTest()
    {
        var resp = await _client.ExecutePrecessStartAsync(new ProcessStartRequest
        {
            ProcessInstId = "caf9afae-5408-4eb7-b4c1-bddabecd96a1"
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }

    /// <summary>
    ///     流程挂起
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessSuspendTest()
    {
        var resp = await _client.ExecutePrecessSuspendAsync(new ProcessSuspendRequest
        {
            ProcessInstId = "caf9afae-5408-4eb7-b4c1-bddabecd96a1"
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }

    /// <summary>
    ///     流程恢复挂起
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessResumeTest()
    {
        var resp = await _client.ExecutePrecessResumeAsync(new ProcessSuspendRequest
        {
            ProcessInstId = "caf9afae-5408-4eb7-b4c1-bddabecd96a1"
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }

    /// <summary>
    ///     流程取消
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessCancelTest()
    {
        var resp = await _client.ExecutePrecessCancelAsync(new ProcessTerminateRequest
        {
            ProcessInstId = "caf9afae-5408-4eb7-b4c1-bddabecd96a1",
            Uid = "PD0001"
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }

    /// <summary>
    ///     流程取消重新激活
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessReactivateTest()
    {
        var resp = await _client.ExecutePrecessReActivateAsync(new ProcessReactivateRequest
        {
            ProcessInstId = "c932cd21-288f-4094-bc94-86f70249535e",
            TargetActivityId = "obj_cab014f6e070000186dd1b7772918a00",
            IsClearHistory = true,
            TargetUID = "system",
            ReactivateReason = "测试",
            Uid = "system"
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }

    /// <summary>
    ///     流程删除
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessDeleteTest()
    {
        var resp = await _client.ExecutePrecessDeleteAsync(new ProcessTerminateRequest
        {
            ProcessInstId = "caf9afae-5408-4eb7-b4c1-bddabecd96a1",
            Uid = "PD0001"
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }

    /// <summary>
    ///     流程终止
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessTerminateTest()
    {
        var resp = await _client.ExecutePrecessTerminateAsync(new ProcessTerminateRequest
        {
            ProcessInstId = "782c8a76-6894-4a00-9bdb-567e90b27c5f",
            Uid = "PD0001"
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }

    /// <summary>
    ///     流程变量列表
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessVarsGetTest()
    {
        var resp = await _client.ExecutePrecessVarsGetAsync(new ProcessBaseRequest
        {
            ProcessInstId = "c932cd21-288f-4094-bc94-86f70249535e"
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }
    /// <summary>
    ///     流程变量列表
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ProcessVarsSetTest()
    {
        var resp = await _client.ExecutePrecessVarSetsAsync(new ProcessVarSetRequest
        {
            ProcessInstId = "c932cd21-288f-4094-bc94-86f70249535e",
            Vars = new Dictionary<string, object>()
            {
                {"IsDsgDraftAppred",false}
            }
        });
        _testOutput.WriteLine($"{resp.ErrorCode}:{resp.ErrorMessage}");
        Assert.Equal("ok", resp.Result);
    }
}