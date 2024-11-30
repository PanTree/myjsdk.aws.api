using System.Text.Json;
using System.Text.Unicode;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using MyjSdk.Aws.ApiClient.Extensions;
using MyjSdk.Aws.ApiClient.Model;
using Volo.Abp.Testing;
using Xunit;
using Xunit.Abstractions;

namespace MyjSdk.Aws.ApiClient.Test.Test;

public sealed class RepositoryExtensionTest : AbpIntegratedTest<MyjAssApiClientTestModule>
{
    private readonly IAwsSidService _sidService;
    private readonly ITestOutputHelper _testOutput;
    private readonly MyjAwsApiClient _client;

    public RepositoryExtensionTest(ITestOutputHelper testOutputHelper)
    {
        var option = GetRequiredService<IOptions<MyjAwsApiClientOptions>>().Value;
        _sidService = GetRequiredService<IAwsSidService>();
        _testOutput = testOutputHelper;
        var clientCache = GetRequiredService<IFlurlClientCache>();
        _client = new MyjAwsApiClient(option, clientCache);
    }

    [Fact]
    public async Task AwsDiagramGetTest()
    {
        var res = await _client.ExecuteDiagramGetAsync(new DiagramGetRequest
        {
            ProcessDefId = "obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd",
            DiagramType = 1
        });
        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);
    }

    [Fact]
    public async Task AwsDiagramUrlGetTest()
    {
        var sid = await _sidService.GetAwsSidAsync("102864");

        var res = await _client.ExecuteDiagramUrlGetAsync(new DiagramUrlGetRequest
        {
            ProcessDefId = "obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd",
            DiagramType = 1,
            Sid = sid
        });
        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);
        /*./df?groupValue=bpmnimg&fileValue=obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd&sid=3a5fcdfa-53d3-42b5-bd0f-41ed2050d1ce&repositoryName=%21appresource&appId=com.awspaas.user.apps.app20230602110119&attachment=true&fileNameShow=%E5%B7%A5%E7%A8%8B-%E8%AE%BE%E8%AE%A1%E6%B5%81%E7%A8%8B-obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd.png&fileName=obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd.png&lastModified=0*/
    }

    [Fact]
    public async Task AwsTackUrlGetTest()
    {
        var sid = await _sidService.GetAwsSidAsync("102864");

        var res = await _client.ExecuteTackUrlGetAsync(new TaskUrlGetRequest
        {
            ProcessInstId = "064d6d72-1022-4a12-8378-f3a36ecc4354",
            Sid = sid
        });
        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);
    }

    [Fact]
    public async Task AwsTUrlGetTest()
    {
        var sid = await _sidService.GetAwsSidAsync("102864");

        var res = await _client.ExecuteDiagramUrlGetAsync(new DiagramUrlGetRequest
        {
            ProcessDefId = "obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd",
            DiagramType = 1,
            Sid = sid
        });
        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);
    }

    [Fact]
    public async Task ProcessGetGetTest()
    {
        var res = await _client.ExecuteProcessGetAsync(new RepositoryProcessGetRequest
        {
            ProcessDefId = "obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd"
        });
        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");

        /*{"quickStart
         ":false,"processAdministrator":"PD0001","securityLayer":false,"nameI18N":"设计流程","cancelTask":false,"wariningTimeDurationText":"0Days,0Hours,0Minutes,0Seconds,0Milliseconds","formSummary":false,"appId":"com.awspaas.user.apps.app20230602110119","versionNo":1,"id":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","matrixDistributed":false,"processGroupNameI18N":"工程审核","historyMaxVersion":14,"dataTrigger":"[]","initSecurityLayer":-1,"timeDuration":0,"tplLockedInfo":"W10=","versionId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","cancelProcessExclusiveRule":"1","draftRemove":true,"name":"设计流程","mapRoleSelectAtStart":false,"leanStandard":0.0,"trackDiagramType":"0","wariningTimeDuration":0,"processLevelType":0,"engineType":0,"transferPriority":false,"processGroupName":"工程审核","categoryName":"工程","versionStatus":0,"resetLostHistory":true,"managed":false,"trackForm":false,"worklistPopMini":true,"processType":"None","class":"com.actionsoft.bpms.bpmn.engine.model.def.ProcessDefinition","ignoreMapRoleSelect":true,"processGroupId":"obj_aabb852ed8144da99d98ff5e01d96212","mobileStart":true,"updateUser":"PD0001","updateTime":1704355583000,"executable":true,"notifyConfig":"{\"taskReminder\":[]}","tpl":false,"createTime":1703474594000,"accessSecurityType":0,"closed":false,"createUser":"PD0001","toString":"[Process][设计流程][obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd]","dataShare":false,"cancelProcess":true}*/

        var d = JsonSerializer.Deserialize<ProcessGetResponse>(res.Data);
        Assert.NotNull(res.Data);
    }

    [Fact]
    public async Task ProcessExtensionGetGetTest()
    {
        var res = await _client.ExecuteProcessExtensionGetAsync(new RepositoryProcessGetRequest
        {
            ProcessDefId = "obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd"
        });
        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");

        /**/
        Assert.NotNull(res.Data);
    }

    [Fact]
    public async Task UserTaskGetGetTest()
    {
        var res = await _client.ExecuteUserTaskGetAsync(new RepositoryUserTaskGetRequest
        {
            ProcessDefId = "obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd",
            UserTaskDefId = "obj_ca932045d2f0000194fe13001e801515"
        });
        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");


        /**/
        Assert.NotNull(res.Data);
    }

    [Fact]
    public async Task ActivityGetTest()
    {
        var sid = await _sidService.GetAwsSidAsync("102864");

        var res = await _client.ExecuteActivityGetAsync(new ActivityGetRequest()
        {
            ProcessDefId = "obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd",
            Sid = sid
        });

        Assert.NotNull(res.Data);
        _testOutput.WriteLine(JsonSerializer.Serialize(res, new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All)
        }));
        /*{"msg":"","result":"ok","data":{"ext":[{"name":"预约量铺时间","extendProperty":[{"value":"1","key":"test","desc":""}],"id":"obj_ca932045d2f0000194fe13001e801515"},{"name":"特殊事务审批","id":"obj_ca93747816a000019a1e6ef04caf1161"},{"name":"提交设计初稿","id":"obj_ca93747d551000012510e7d01cb0f100"},{"name":"提交量铺资料","id":"obj_ca93746b0fc000014cb538c41fc0e200"},{"name":"设计稿审批","id":"obj_ca93749c01600001254547a01fe81d70"},{"name":"提交设计要求","extendProperty":[{"value":"2","key":"type","desc":"hello"}],"id":"obj_ca93746ea08000016cedae0019941f6e"},{"name":"设计稿确认","id":"obj_ca9374a10a1000012fa39a2c1c021781"},{"name":"安排量铺","id":"obj_316fe01609534810bbb9bb38173f6b90"},{"name":"量铺资料确认","id":"obj_ca93748ab360000165e1221e2dd01a2c"},{"name":"提交设计终稿","id":"obj_ca9374a3ca500001b2d31d70c4c01a25"}],"activityList":[{"no":1,"name":"预约量铺时间","id":"obj_ca932045d2f0000194fe13001e801515","type":"userTask","customId":""},{"no":1,"name":"特殊事务审批","id":"obj_ca93747816a000019a1e6ef04caf1161","type":"userTask","customId":""},{"no":1,"name":"提交设计初稿","id":"obj_ca93747d551000012510e7d01cb0f100","type":"userTask","customId":""},{"no":1,"name":"提交量铺资料","id":"obj_ca93746b0fc000014cb538c41fc0e200","type":"userTask","customId":""},{"no":1,"name":"设计稿审批","id":"obj_ca93749c01600001254547a01fe81d70","type":"userTask","customId":""},{"no":1,"name":"提交设计要求","id":"obj_ca93746ea08000016cedae0019941f6e","type":"userTask","customId":""},{"no":1,"name":"设计稿确认","id":"obj_ca9374a10a1000012fa39a2c1c021781","type":"userTask","customId":""},{"no":1,"name":"安排量铺","id":"obj_316fe01609534810bbb9bb38173f6b90","type":"userTask","customId":""},{"no":1,"name":"量铺资料确认","id":"obj_ca93748ab360000165e1221e2dd01a2c","type":"userTask","customId":""},{"no":1,"name":"提交设计终稿","id":"obj_ca9374a3ca500001b2d31d70c4c01a25","type":"userTask","customId":""}]},"id":":RO;"}*/

    }
}