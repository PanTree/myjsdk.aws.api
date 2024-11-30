

namespace MyjSdk.Aws.ApiClient
{
    public interface IAwsSidService 
    {
        Task<string?> GetAwsSidAsync(string uid);
    }
}
