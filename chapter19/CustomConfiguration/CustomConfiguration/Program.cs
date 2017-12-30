using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CustomConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, config) => // #A
                {
                    config.AddXmlFile("baseconfig.xml"); // #B

                    var partialConfig = config.Build(); // #C
                    var filename = partialConfig["SettingsFile"]; //#D

                    config.AddJsonFile(filename) // #E
                        .AddEnvironmentVariables(); // #E
                })
                .UseStartup<Startup>()
                .Build();
    }
}
