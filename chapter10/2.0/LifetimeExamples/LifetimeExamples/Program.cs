using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LifetimeExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(options => 
                {
                    // set the value to true to always validate scopes,
                    // or use the alternative definition below to only
                    // validate in dev environments
                    options.ValidateScopes = false;
                })
                //.UseDefaultServiceProvider((ctx, options) =>
                //{
                //    options.ValidateScopes = ctx.HostingEnvironment.IsDevelopment();
                //})
                .Build();
    }
}
