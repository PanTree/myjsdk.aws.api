using Flurl.Http;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace MyjSdk.FlurlHttpClient;

public interface IFlurlErrorLogger : IFlurlEventHandler { }

public class FlurlErrorLogger : FlurlEventHandler, IFlurlErrorLogger
{
    private readonly ILogger _logger;

    public FlurlErrorLogger(ILogger<FlurlErrorLogger> logger)
    {
        _logger = logger;
    }


    public override  Task HandleAsync(FlurlEventType eventType, FlurlCall call)
    {
        call.ExceptionHandled = true;
        throw new BusinessException(code:"403",message:$"{call.Exception.Message}:{call.Exception.InnerException?.Message}");
    }
}