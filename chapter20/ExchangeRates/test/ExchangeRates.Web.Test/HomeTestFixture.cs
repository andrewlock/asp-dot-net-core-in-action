using System;
using System.IO;
using System.Net.Http;
using ExchangeRates.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace ExchangeRateHelper.Test
{
    public class HomeTestFixture : IDisposable
    {
        public HomeTestFixture()
        {
            var projectRootPath = Path.Combine(
              Directory.GetCurrentDirectory(),
              "..", "..", "..", "..", "..", "src", "ExchangeRates.Web");

            var builder = Program.CreateWebHostBuilder()
                .UseContentRoot(projectRootPath);

            Server = new TestServer(builder);

            Client = Server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost");
        }

        public HttpClient Client { get; }
        public TestServer Server { get; }

        public void Dispose()
        {
            Client?.Dispose();
            Server?.Dispose();
        }
    }

}
