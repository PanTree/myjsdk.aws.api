using Volo.Abp;
using Volo.Abp.Modularity;

namespace MyjSdk.Aws.ApiClient.Test
{

    [DependsOn(
        typeof(AbpTestBaseModule),
        typeof(MyjAwsApiClientModule),
        typeof(AbpTestBaseModule)
    )]
    public class MyjAssApiClientTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<MyjAwsApiClientOptions>(options =>
            {
                options.Endpoint = "https://mbpm-test.meiyijia.com.cn";
                options.AccessKey = "awsTEST";
                options.AppSecret = "AA564";
                options.DefaultUId = "system";
            });
        }
    }
}

