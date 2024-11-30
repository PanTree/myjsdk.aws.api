using System.Collections;

namespace MyjSdk.FlurlHttpClient.Interception;

/// <summary>
/// 请求事件集合
/// </summary>
public sealed class FlurlHttpCallInterceptorCollection : IEnumerable<FlurlHttpCallInterceptor>
{
    private readonly IList<FlurlHttpCallInterceptor> _list;

    public FlurlHttpCallInterceptorCollection()
    {
        _list = new List<FlurlHttpCallInterceptor>();
    }

    public int Count => _list.Count;

    public FlurlHttpCallInterceptor this[int index] => _list[index];

    public IEnumerator<FlurlHttpCallInterceptor> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_list).GetEnumerator();
    }

    public void Add(FlurlHttpCallInterceptor interceptor)
    {
        _list.Add(interceptor);
    }

    public void Remove(FlurlHttpCallInterceptor interceptor)
    {
        _list.Remove(interceptor);
    }
}