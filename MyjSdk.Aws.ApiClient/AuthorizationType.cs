namespace MyjSdk.Aws.ApiClient;

/// <summary>
/// 认证类型
/// </summary>
public enum AuthorizationType
{
    /// <summary>
    /// 签名
    /// </summary>
    Signature = 0,
    /// <summary>
    /// basicAuth
    /// </summary>
    BasicAuth = 1
}