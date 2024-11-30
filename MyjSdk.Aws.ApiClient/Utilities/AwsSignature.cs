using System.Text;
using NETCore.Encrypt;

namespace MyjSdk.Aws.ApiClient.Utilities;

public static class AwsSignature
{
    public const string SigMethod = "sig_method";
    private const string HmacSha256 = "HmacSHA256";

    /// <summary>
    ///     签密
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="secret"></param>
    /// <returns></returns>
    public static string MakeSign(Dictionary<string, string?> parameters, string secret)
    {
        var signStr = $"{secret}{SortParamsByAscii(parameters)}";
        return parameters.ContainsKey(SigMethod) && parameters[SigMethod]!.Equals(HmacSha256)
            ? EncryptProvider.HMACSHA256(signStr, secret).ToUpper()
            : EncryptProvider.HMACMD5(signStr, secret).ToUpper();
    }

    /// <summary>
    ///     ascii升序
    /// </summary>
    /// <param name="paramsMap"></param>
    /// <returns></returns>
    private static string SortParamsByAscii(IDictionary<string, string?> paramsMap)
    {
        var keys = paramsMap.Where(c => !string.IsNullOrEmpty(c.Value)).ToDictionary().Keys.ToArray();
        Array.Sort(keys, string.CompareOrdinal);

        var stringBuilder = new StringBuilder();
        foreach (var key in keys)
        {
            //  var keycode = HttpUtility.UrlEncode(key, Encoding.UTF8);
            //  var value = HttpUtility.UrlEncode(paramsMap[key], Encoding.UTF8);
            stringBuilder.Append($"{key}{paramsMap[key]}");
        }

        return stringBuilder.ToString();
    }
}

