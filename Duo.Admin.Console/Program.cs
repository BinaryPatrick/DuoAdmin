using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Unf.Core.Duo;
using Unf.Core.Duo.Models;

namespace Duo.Admin.Console
{
    internal class Program
    {
        private static async Task Main()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDuoServices((options) =>
            {
                options.Host = "api-XXXXXXXX.duosecurity.com";
                options.IntegrationKey = "*** Your Integration Key Here ***";
                options.SecretKey = "*** Your Secret Key Here ***";
            });
            ServiceProvider sp = services.BuildServiceProvider();

            IDuoAdapter adapter = sp.GetService<IDuoAdapter>();
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/admin/v1/users?limit=10"))
            {
                List<User> users = await adapter.MakeRequest<List<User>>(request);
                System.Console.WriteLine(JsonConvert.SerializeObject(users));
            }
        }
    }
}
