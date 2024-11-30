using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using MyjSdk.Aws.ApiClient.Extensions;
using MyjSdk.Aws.ApiClient.Model;
using System.Text.Json;
using System.Text.Unicode;
using Volo.Abp.Testing;
using Xunit;
using Xunit.Abstractions;

namespace MyjSdk.Aws.ApiClient.Test.Test;

public sealed class TaskClientTest : AbpIntegratedTest<MyjAssApiClientTestModule>
{
    private readonly IAwsSidService _sidService;
    private readonly ITestOutputHelper _testOutput;
    private readonly MyjAwsApiClient _client;

    public TaskClientTest(ITestOutputHelper testOutputHelper)
    {
        var option = GetRequiredService<IOptions<MyjAwsApiClientOptions>>().Value;
        var clientCache = GetRequiredService<IFlurlClientCache>();
        _sidService = GetRequiredService<IAwsSidService>();
        _testOutput = testOutputHelper;
        _client = new MyjAwsApiClient(option, clientCache);
    }


    [Fact]
    public async Task TaskCompleteTest()
    {
        var res = await _client.ExecuteTaskCompleteAsync(new TaskCompleteRequest
        {
            TaskInstId = "cc3ac5c3-afa3-44a2-9f28-749e4df47c66",
            Uid = "PD0001",
            Vars = ""
        });
        /*{"data":{"isProcessEnd":false,"historyTasks":[{"EAITask":false,"IOBD":"","IOC":"","IOR":"","IOS":"","activityDefId":"obj_ca93748ab360000165e1221e2dd01a2c","activityType":"userTask","appId":"com.awspaas.user.apps.app20230602110119","async":false,"beginEngineNode":"192.168.112.24:10008","beginTime":1705388767000,"claimResourceId":"","claimType":0,"controlState":"complete","delayTimes":0,"delegate":false,"delegateUser":"","dispatchId":"82c53014-0c9b-409e-8457-f841b73800e5","draft":false,"endEngineNode":"192.168.112.24:10008","executeCostTime":1341126,"executeExpireTime":0,"ext1":"","ext2":"","ext3":"","ext4":"","ext5":"","ext6":"","ext7":0,"ext8":0.0,"formSummary":"","historyTask":false,"id":"cc3ac5c3-afa3-44a2-9f28-749e4df47c66","monitor":false,"owner":"PD0001","ownerDepartmentId":"1004000000000010009","parentTaskInstId":"3f85375f-b0f5-4e2e-8b3a-be248e6a00e9","priority":1,"processDefId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processDefVerId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processGroupId":"obj_aabb852ed8144da99d98ff5e01d96212","processInstId":"e82e5f73-fee9-4b5e-8327-47955ed6d0c6","readState":1,"readTime":1705389839000,"remindTimes":0,"root":false,"scopeId":"3f85375f-b0f5-4e2e-8b3a-be248e6a00e9","securityLevel":0,"state":1,"target":"PD0001","targetCompanyId":"8911e732-b42a-4556-853f-ad32761bcbee","targetDepartmentId":"1004000000000010009","targetRoleId":"e5591c54-2af8-4622-93ec-d803594d1e51","taskInfo":"","title":"(量铺资料确认)测试123","trash":true,"undo":true}],"activeTasks":[{"EAITask":false,"IOBD":"","IOC":"","IOR":"","IOS":"","activityDefId":"obj_ca93747d551000012510e7d01cb0f100","activityType":"userTask","async":false,"beginEngineNode":"192.168.112.24:10008","beginTime":1705390108999,"claimResourceId":"","claimType":0,"controlState":"active","delayTimes":0,"delegateUser":"","dispatchId":"54414975-c82e-4a57-a071-d012f8f802a0","draft":false,"ext1":"","ext2":"","ext3":"","ext4":"","ext5":"","ext6":"","ext7":0,"ext8":0.0,"formSummary":"","historyTask":false,"id":"6d9912c0-42b4-478a-b5df-c1d5106b541c","monitor":false,"owner":"PD0001","ownerDepartmentId":"1004000000000010009","parentTaskInstId":"cc3ac5c3-afa3-44a2-9f28-749e4df47c66","priority":1,"processDefId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processDefVerId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processGroupId":"obj_aabb852ed8144da99d98ff5e01d96212","processInstId":"e82e5f73-fee9-4b5e-8327-47955ed6d0c6","readState":0,"remindTimes":0,"root":false,"scopeId":"cc3ac5c3-afa3-44a2-9f28-749e4df47c66","securityLevel":0,"state":1,"target":"PD0001","targetCompanyId":"8911e732-b42a-4556-853f-ad32761bcbee","targetDepartmentId":"1004000000000010009","targetRoleId":"e5591c54-2af8-4622-93ec-d803594d1e51","taskInfo":"","title":"(提交设计初稿)测试123","trash":true}],"tracks":[{"description":"[complete]","objectList":[{"EAITask":false,"IOBD":"","IOC":"","IOR":"","IOS":"","activityDefId":"obj_ca93748ab360000165e1221e2dd01a2c","activityType":"userTask","appId":"com.awspaas.user.apps.app20230602110119","async":false,"beginEngineNode":"192.168.112.24:10008","beginTime":1705388767000,"claimResourceId":"","claimType":0,"controlState":"complete","delayTimes":0,"delegate":false,"delegateUser":"","dispatchId":"82c53014-0c9b-409e-8457-f841b73800e5","draft":false,"endEngineNode":"192.168.112.24:10008","executeCostTime":1341126,"executeExpireTime":0,"ext1":"","ext2":"","ext3":"","ext4":"","ext5":"","ext6":"","ext7":0,"ext8":0.0,"formSummary":"","historyTask":false,"id":"cc3ac5c3-afa3-44a2-9f28-749e4df47c66","monitor":false,"owner":"PD0001","ownerDepartmentId":"1004000000000010009","parentTaskInstId":"3f85375f-b0f5-4e2e-8b3a-be248e6a00e9","priority":1,"processDefId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processDefVerId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processGroupId":"obj_aabb852ed8144da99d98ff5e01d96212","processInstId":"e82e5f73-fee9-4b5e-8327-47955ed6d0c6","readState":1,"readTime":1705389839000,"remindTimes":0,"root":false,"scopeId":"3f85375f-b0f5-4e2e-8b3a-be248e6a00e9","securityLevel":0,"state":1,"target":"PD0001","targetCompanyId":"8911e732-b42a-4556-853f-ad32761bcbee","targetDepartmentId":"1004000000000010009","targetRoleId":"e5591c54-2af8-4622-93ec-d803594d1e51","taskInfo":"","title":"(量铺资料确认)测试123","trash":true,"undo":true}],"wellDescription":"[任务已处理完毕]"},{"description":"[pass]2 of 1 joined","wellDescription":"[pass]2 of 1 joined"},{"description":"[create][PD0001<招财猫测试账号>]","objectList":[{"EAITask":false,"IOBD":"","IOC":"","IOR":"","IOS":"","activityDefId":"obj_ca93747d551000012510e7d01cb0f100","activityType":"userTask","async":false,"beginEngineNode":"192.168.112.24:10008","beginTime":1705390108999,"claimResourceId":"","claimType":0,"controlState":"active","delayTimes":0,"delegateUser":"","dispatchId":"54414975-c82e-4a57-a071-d012f8f802a0","draft":false,"ext1":"","ext2":"","ext3":"","ext4":"","ext5":"","ext6":"","ext7":0,"ext8":0.0,"formSummary":"","historyTask":false,"id":"6d9912c0-42b4-478a-b5df-c1d5106b541c","monitor":false,"owner":"PD0001","ownerDepartmentId":"1004000000000010009","parentTaskInstId":"cc3ac5c3-afa3-44a2-9f28-749e4df47c66","priority":1,"processDefId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processDefVerId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processGroupId":"obj_aabb852ed8144da99d98ff5e01d96212","processInstId":"e82e5f73-fee9-4b5e-8327-47955ed6d0c6","readState":0,"remindTimes":0,"root":false,"scopeId":"cc3ac5c3-afa3-44a2-9f28-749e4df47c66","securityLevel":0,"state":1,"target":"PD0001","targetCompanyId":"8911e732-b42a-4556-853f-ad32761bcbee","targetDepartmentId":"1004000000000010009","targetRoleId":"e5591c54-2af8-4622-93ec-d803594d1e51","taskInfo":"","title":"(提交设计初稿)测试123","trash":true}],"wellDescription":"[任务已创建成功][PD0001<招财猫测试账号>]"}]},"result":"ok"}*/
        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);
    }

    [Fact]
    public async Task TaskRollbackTest()
    {
        var res = await _client.ExecuteTaskRollBackAsync(new TaskRollbackRequest
        {
            TaskInstId = "5166ecc3-3592-4d5d-9068-1cbaea2f0353",
            Uid = "system",
            TargetActivityId = "obj_cab015225f1000013edb5230d420d1b0",
            IsCompensation = false,
            RollbackReason = "测试"
        });

        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);

        /*{"data":{"EAITask":false,"IOBD":"","IOC":"","IOR":"","IOS":"","activityDefId":"obj_ca93748ab360000165e1221e2dd01a2c","activityType":"userTask","async":false,"beginEngineNode":"192.168.112.24:10008","beginTime":1705388766777,"claimResourceId":"","claimType":0,"controlState":"active","delegateUser":"","dispatchId":"82c53014-0c9b-409e-8457-f841b73800e5","ext1":"","ext2":"","ext3":"","historyTask":false,"id":"cc3ac5c3-afa3-44a2-9f28-749e4df47c66","monitor":false,"owner":"PD0001","ownerDepartmentId":"1004000000000010009","parentTaskInstId":"3f85375f-b0f5-4e2e-8b3a-be248e6a00e9","priority":1,"processDefId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processDefVerId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processGroupId":"obj_aabb852ed8144da99d98ff5e01d96212","processInstId":"e82e5f73-fee9-4b5e-8327-47955ed6d0c6","root":false,"scopeId":"3f85375f-b0f5-4e2e-8b3a-be248e6a00e9","state":1,"target":"PD0001","targetCompanyId":"8911e732-b42a-4556-853f-ad32761bcbee","targetDepartmentId":"1004000000000010009","targetRoleId":"e5591c54-2af8-4622-93ec-d803594d1e51","taskInfo":"","title":"(量铺资料确认)测试123"},"result":"ok"}*/
    }

    [Fact]
    public async Task TaskQueryTest()
    {
        var res = await _client.ExecuteTaskQueryAsync(new TaskQueryRequest
        {
            ProcessInstId = "0f2cf433-b141-4b59-9e5b-a71fcfabc02f"
        });

        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);

        /*{"data":[{"EAITask":false,"IOBD":"","IOC":"","IOR":"","IOS":"","activityDefId":"obj_ca93748ab360000165e1221e2dd01a2c","activityType":"userTask","async":false,"beginEngineNode":"192.168.112.24:10008","beginTime":1705390722000,"claimResourceId":"","claimType":0,"controlState":"active","delegateUser":"","dispatchId":"75d97522-c827-4ab0-a18d-9b2563614a44","ext1":"","ext2":"","ext3":"","historyTask":false,"id":"c40aef07-0263-4d73-8d26-3466da23d684","monitor":false,"owner":"PD0001","ownerDepartmentId":"1004000000000010009","parentTaskInstId":"6d9912c0-42b4-478a-b5df-c1d5106b541c","priority":1,"processDefId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processDefVerId":"obj_92ed9f4bb8824b2f87ee6ccd1cabe6cd","processGroupId":"obj_aabb852ed8144da99d98ff5e01d96212","processInstId":"e82e5f73-fee9-4b5e-8327-47955ed6d0c6","root":false,"scopeId":"6d9912c0-42b4-478a-b5df-c1d5106b541c","state":1,"target":"PD0001","targetCompanyId":"8911e732-b42a-4556-853f-ad32761bcbee","targetDepartmentId":"1004000000000010009","targetRoleId":"e5591c54-2af8-4622-93ec-d803594d1e51","taskInfo":"","title":"(量铺资料确认)测试123"}],"result":"ok"}*/
    }


    [Fact]
    public async Task TaskHistoryQueryPageTest()
    {
        var res = await _client.ExecuteTaskHistoryQueryPageAsync(new TaskHistoryQueryPageRequest
        {
            ProcessInstId = "c932cd21-288f-4094-bc94-86f70249535e"
        });

        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);

        /**/
    }

    [Fact]
    public async Task TaskPresGetTest()
    {
        var res = await _client.ExecuteTaskPresGetAsync(new TaskPresGetRequest
        {
            BeginTaskInstId = "af19f498-23f3-4e93-acdf-b64d8400f726",
            EndTaskInstId = "66ea1a11-78d3-4a0d-8188-200da96d576f"
        });

        _testOutput.WriteLine($"{res.ErrorCode}:{res.ErrorMessage}");
        Assert.NotNull(res.Data);

        /**/
    }

    [Fact]
    public async Task TaskActivityGetTest()
    {
        var sid = await _sidService.GetAwsSidAsync("system");
        var res = await _client.ExecuteTaskActivityGetAsync(new TaskActivityGetRequest()
        {
            ProcessInstId = "c932cd21-288f-4094-bc94-86f70249535e",
            Sid = sid
        });

        Assert.NotNull(res.Data);
        _testOutput.WriteLine(JsonSerializer.Serialize(res, new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All)
        }));
        /*{"data":{"taskList":[{"activityId":"obj_ca545c54f510000115b91e701560fbc0","activityType":"userTask","controlState":"active","id":"edf905d8-da1e-4f31-a7a4-cd10bb3d240f","startTime":"2023-06-23 06:49:18","title":"(总经理)[空标题]","endTime":""},{"activityId":"obj_ca526ede0db00001b56915fa146e56b0","activityType":"userTask","controlState":"complete","id":"0d7eedc4-9da4-4aee-b817-08c7db3ba00c","startTime":"2023-06-23 06:47:54","title":"(部门经理)[空标题]","endTime":"2023-06-23 06:49:10"},{"activityId":"obj_ca526ed2c4400001a54b1e7883c011d6","activityType":"userTask","controlState":"complete","id":"4f3b8020-f84f-43e9-8208-d4d408dba5ba","startTime":"2023-06-23 06:47:48","title":"(HRBP审批)[空标题]","endTime":"2023-06-23 06:47:54"},{"activityId":"obj_683e923840994bafa16b5dcaa4f610d0","activityType":"userTask","controlState":"complete","id":"76e61724-5bf6-487e-8e85-c6bdd4842193","startTime":"2023-06-23 06:49:10","title":"(部门总监)[空标题]","endTime":"2023-06-23 06:49:18"},{"activityId":"obj_94f05bffb0844d8d93036bff887fbf40","activityType":"userTask","controlState":"complete","id":"bf93d13c-9254-4997-b4fc-e5c3eae72174","startTime":"2023-06-23 06:47:21","title":"(填写)[空标题]","endTime":"2023-06-23 06:47:48"}]},"errorCode":null,"msg":"","result":"ok"}*/
    }
}