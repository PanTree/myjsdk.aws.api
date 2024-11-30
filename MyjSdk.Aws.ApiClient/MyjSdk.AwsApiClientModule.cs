using Microsoft.Extensions.DependencyInjection;
using MyjSdk.FlurlHttpClient;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace MyjSdk.Aws.ApiClient;

[DependsOn(
    typeof(MyjFlurlHttpClientModule),
    typeof(AbpCachingModule))]
public class MyjAwsApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        context.Services.AddSingleton<IAwsSidService, AwsSidService>();
        context.Services.Configure<MyjAwsApiClientOptions>(configuration.GetSection(nameof(MyjAwsApiClientOptions)));
    }
}