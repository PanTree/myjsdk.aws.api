using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace MyjSdk.FlurlHttpClient
{
    
    public class MyjFlurlHttpClientModule:AbpModule
    {
      
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<IFlurlErrorLogger, FlurlErrorLogger>();

            context.Services.AddSingleton<IFlurlClientCache>(_=>new FlurlClientCache()
               .WithDefaults(builder=>
                   builder.EventHandlers.Add((FlurlEventType.OnError,_.GetService<IFlurlErrorLogger>())))
           );
        }
    }
}
