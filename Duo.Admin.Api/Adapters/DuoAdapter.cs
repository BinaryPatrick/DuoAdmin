using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Unf.Core.Duo.Models;

namespace Unf.Core.Duo.Adapters
{
    public class DuoAdapter : IDuoAdapter
    {
        private readonly DuoOptions _options;

        public DuoAdapter(IOptions<DuoOptions> options)
        {
            _options = options.Value;
        }

        public async Task<string> MakeRequest(HttpRequestMessage requestMessage)
        {
            if (!requestMessage.RequestUri.IsAbsoluteUri)
            {
                requestMessage.RequestUri = new Uri($"https://{_options.Host}{requestMessage.RequestUri.ToString()}");
            }
            string signature = await requestMessage.GetRequestSignatureAsync(_options.SecretKey);
            string authHeaderValue = $"{_options.IntegrationKey}:{signature}".ToBase64(new ASCIIEncoding());
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<T> MakeRequest<T>(HttpRequestMessage requestMessage)
        {
            string content = await MakeRequest(requestMessage);
            DuoResponse<T> response = JsonConvert.DeserializeObject<DuoResponse<T>>(content);
            return response.Content;
        }

        public async Task<IEnumerable<T>> MakePagedRequest<T>(HttpRequestMessage requestMessage, bool getAllPages)
        {
            List<T> results = new List<T>();
            string content = await MakeRequest(requestMessage);
            DuoResponse<T> response = JsonConvert.DeserializeObject<DuoResponse<T>>(content);
            results.Add(response.Content);

            if (requestMessage.Method == HttpMethod.Get && getAllPages && response.Metadata?.NextOffset > 0)
            {
                string parameters = requestMessage.RequestUri.Query
                    .Replace("?", string.Empty)
                    .Split('&')
                    .Where(x => !x.StartsWith("offset=", StringComparison.OrdinalIgnoreCase))
                    .Prepend($"offset={response.Metadata.NextOffset}")
                    .Aggregate((a, b) => $"{a}&{b}");
                string url = $"{requestMessage.RequestUri.Scheme}://{requestMessage.RequestUri.Host}{requestMessage.RequestUri.AbsolutePath}?{parameters}";

                using (requestMessage = new HttpRequestMessage(requestMessage.Method, url))
                {
                    requestMessage.Content = requestMessage.Content;
                    results.AddRange(await MakePagedRequest<T>(requestMessage, getAllPages));
                }
            }
            return results;
        }
    }
}
