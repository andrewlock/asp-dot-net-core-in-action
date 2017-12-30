using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomMiddleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            //app.Run(async context =>
            //{
            //    context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync(DateTime.UtcNow.ToString());
            //});

            app.Map("/ping", branch =>
            {
                branch.Run(async ctx =>
                {
                    ctx.Response.ContentType = "text/plain";
                    await ctx.Response.WriteAsync("pong");
                });
            });

            //app.UseMiddleware<HeadersMiddleware>();
            //app.UseMiddleware<VersionMiddleware>();

            app.UseSecurityHeaders();
            app.UseVersionEndpoint();
            app.UsePingEndpoint();
            app.UseCalculatorMiddleware();

            //app.Run(async ctx =>
            //{
            //    ctx.Response.ContentType = "text/plain";
            //    await ctx.Response.WriteAsync("It's alive!");
            //});

            //app.Map("/ping", branch =>
            //{
            //    branch.Run(async ctx =>
            //    {
            //        ctx.Response.ContentType = "text/plain";
            //        await ctx.Response.WriteAsync("pong");
            //    });
            //});

            //app.Use(async (context, next) =>
            //{
            //    context.Response.OnStarting(() =>
            //    {
            //        context.Response.Headers["Strict-Transport-Security"] = $"max-age=30";
            //        return Task.CompletedTask;
            //    });
            //    await next.Invoke();
            //});

            app.UseMvc();
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HeadersMiddleware>();
        }

        public static IApplicationBuilder UseVersionEndpoint(this IApplicationBuilder app)
        {
            return app.Map("/version",
                branch => branch.UseMiddleware<VersionMiddleware>());
        }

        public static IApplicationBuilder UsePingEndpoint(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/ping"))
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("pong");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        public static IApplicationBuilder UseCalculatorMiddleware(this IApplicationBuilder app)
        {
            return app.Map("/add", branch =>
            {
                branch.Run(async context =>
                {
                    var query = context.Request.Query;
                    if (int.TryParse(query["a"], out int a) &&
                       int.TryParse(query["b"], out int b))
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync($"{a} + {b} = {a + b}");
                    }
                    else
                    {
                        //bad request
                        context.Response.StatusCode = 400;
                    }
                });
            });
        }
    }

}
