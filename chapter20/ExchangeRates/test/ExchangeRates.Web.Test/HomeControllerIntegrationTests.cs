using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExchangeRates.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using Xunit;

namespace ExchangeRateHelper.Test
{
    public class HomeControllerIntegrationTests : IClassFixture<HomeTestFixture>
    {
        private readonly HomeTestFixture _fixture;

        public HomeControllerIntegrationTests(HomeTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task IndexReturnsHtml()
        {
            var projectRootPath = Path.Combine(Directory.GetCurrentDirectory(),
                "..", "..", "..", "..", "..", "src", "ExchangeRates.Web");

            var builder = new WebHostBuilder()
                .UseContentRoot(projectRootPath)
                .UseEnvironment("Development")
                .UseStartup<Startup>();

            using (var server = new TestServer(builder))
            {

                var client = server.CreateClient();

                // Act
                var response = await client.GetAsync("/");

                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                Assert.Contains("<p>Enter values and click convert</p>", content);
            }
        }

        [Fact]
        public async Task IndexUsingCreateDefaultBuilderReturnsHtml()
        {
            var projectRootPath = Path.Combine(Directory.GetCurrentDirectory(),
                "..", "..", "..", "..", "..", "src", "ExchangeRates.Web");

            var builder = WebHost.CreateDefaultBuilder()
                .UseContentRoot(projectRootPath)
                .UseStartup<Startup>();

            using (var server = new TestServer(builder))
            {

                var client = server.CreateClient();

                // Act
                var response = await client.GetAsync("/");

                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                Assert.Contains("<p>Enter values and click convert</p>", content);
            }

        }

        [Fact]
        public async Task IndexUsingProgramReturnsHtml()
        {
            var projectRootPath = Path.Combine(Directory.GetCurrentDirectory(),
                "..", "..", "..", "..", "..", "src", "ExchangeRates.Web");

            var builder = Program.CreateWebHostBuilder()
                .UseContentRoot(projectRootPath);

            using (var server = new TestServer(builder))
            {

                var client = server.CreateClient();

                // Act
                var response = await client.GetAsync("/");

                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                Assert.Contains("<p>Enter values and click convert</p>", content);
            }

        }

        [Fact]
        public async Task IndexUsingFixtureReturnsHtml()
        {
            // Act
            var response = await _fixture.Client.GetAsync("/");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.Contains("<p>Enter values and click convert</p>", content);
        }
    }
}
