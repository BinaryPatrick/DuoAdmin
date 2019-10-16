using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Unf.Core.Duo
{
    public interface IDuoAdapter
    {
        Task<string> MakeRequest(HttpRequestMessage requestMessage);

        Task<T> MakeRequest<T>(HttpRequestMessage requestMessage);

        Task<IEnumerable<T>> MakePagedRequest<T>(HttpRequestMessage requestMessage, bool getAllPages = false);
    }
}