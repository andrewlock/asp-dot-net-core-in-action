using System;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace ExchangeRateHelper.Test
{
    public class TestFixture<TStartup> : IDisposable where TStartup : class
    {
        public TestFixture()
        {
            var builder = WebHost.CreateDefaultBuilder()
                .UseStartup<TStartup>();
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
