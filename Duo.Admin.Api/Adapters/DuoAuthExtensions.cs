using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Unf.Core.Duo.Adapters
{
    internal static class DuoAuthExtensions
    {
        internal static async Task<string> GetRequestSignatureAsync(this HttpRequestMessage requestMessage, string secret)
        {
            IEnumerable<string> @params = await requestMessage.GetRequestParameters();
            string paramsStr = @params.Aggregate((a, b) => $"{a}\n{b}");
            string signature = GetParamSignature(secret, paramsStr);
            return signature;
        }

        internal static string GetParamSignature(string secret, string @params)
        {
            byte[] secretBytes = Encoding.ASCII.GetBytes(secret);
            using (HMACSHA1 hmac = new HMACSHA1(secretBytes))
            {
                byte[] databytes = Encoding.ASCII.GetBytes(@params);
                byte[] hash = hmac.ComputeHash(databytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        internal static async Task<IEnumerable<string>> GetRequestParameters(this HttpRequestMessage requestMessage)
        {
            if (!requestMessage.Headers.Date.HasValue)
            {
                requestMessage.Headers.Date = DateTime.UtcNow;
            }
            string content = requestMessage.Method == HttpMethod.Get ? requestMessage.RequestUri.Query : await requestMessage.Content.ReadAsStringAsync();
            return new string[]
            {
                DateTime.UtcNow.ToString("r"),
                requestMessage.Method.Method.ToUpperInvariant(),
                requestMessage.RequestUri.Host.ToLower(),
                requestMessage.RequestUri.AbsolutePath,
                content.TrimStart('?').Split('&').OrderBy(x => x).Aggregate((a, b) => $"{a}&{b}"),
            };
        }
    }
}
