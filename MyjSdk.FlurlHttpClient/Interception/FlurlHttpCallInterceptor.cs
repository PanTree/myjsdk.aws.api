using Flurl.Http;

namespace MyjSdk.FlurlHttpClient.Interception;

public abstract class FlurlHttpCallInterceptor
{
    public virtual Task BeforeCallAsync(FlurlCall flurlCall)
    {
        return Task.CompletedTask;
    }

    public virtual Task AfterCallAsync(FlurlCall flurlCall)
    {
        return Task.CompletedTask;
    }
}