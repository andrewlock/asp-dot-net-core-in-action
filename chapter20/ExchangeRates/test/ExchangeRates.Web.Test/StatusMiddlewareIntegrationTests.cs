using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExchangeRates.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace ExchangeRateHelper.Test
{
    public class StatusMiddlewareIntegrationTests : IClassFixture<TestFixture<Startup>>
    {
        public StatusMiddlewareIntegrationTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task StatusMiddlewareReturnsPong()
        {
            var hostBuilder = new WebHostBuilder()
              .Configure(app =>
              {
                  app.UseMiddleware<StatusMiddleware>();
              });

            using (var server = new TestServer(hostBuilder))
            {
                // Act
                var response = await server.CreateRequest("/ping")
                    .SendAsync("GET");

                // Assert
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                Assert.Equal("pong", content);
            }
        }

        [Fact]
        public async Task StatusMiddlewareReturnsPongUsingClient()
        {
            var hostBuilder = new WebHostBuilder()
              .Configure(app =>
              {
                  app.UseMiddleware<StatusMiddleware>();
              });

            using (var server = new TestServer(hostBuilder))
            {
                // Act
                var client = server.CreateClient();
                
                var response = await client.GetAsync("/ping");

                // Assert
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                Assert.Equal("pong", content);
            }
        }

        [Fact]
        public async Task StatusMiddlewareReturnsPongUsingStartup()
        {
            // Act
            var response = await Client.GetAsync("/ping");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal("pong", content);
        }
    }
}
