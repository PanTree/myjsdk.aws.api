using MyjSdk.FlurlHttpClient;

namespace MyjSdk.Aws.ApiClient
{
    public interface IInferable<TRequest, TResponse>
        where TRequest : MyjAwsApiRequest
        where TResponse : ICommonResponse
    {
    }
}


