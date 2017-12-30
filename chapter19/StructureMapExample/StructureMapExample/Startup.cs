using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StructureMap;

namespace StructureMapExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddMvc()
                .AddControllersAsServices();

            return ConfigureStructureMap(services);
        }

        private IServiceProvider ConfigureStructureMap(IServiceCollection services)
        {
            var container = new StructureMap.Container();

            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    // Automatically register services that follow default conventions, e.g.
                    // PurchasingService/IPurchasingService
                    // ConcreteService (concrete types can always be resolved)
                    // Typically, you will have a lot of Service/IService pairs in your app
                    _.AssemblyContainingType(typeof(Startup));
                    _.WithDefaultConventions();
                    // Register all of the implementations of IGamingService
                    // CrosswordService
                    // SudokuService
                    _.AddAllTypesOf<IGamingService>();
                    // Register all non-generic implementations of IValidatior<T> (UserModelValidator)
                    _.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
                });

                // When a ILeaderboard<T> is requested, use Leaderboard<T>
                config.For(typeof(ILeaderboard<>)).Use(typeof(Leaderboard<>));
                // When an IUnitOfWork<T> is requested, run the lambda
                // Also, has a "scoped" lifetime, instead of the default "transient" lifetime
                config.For<IUnitOfWork>().Use(_ => new UnitOfWork(3)).ContainerScoped();
                // For a given T, when an IValidator<T> is requested, 
                // but there are no non-generic implementations of IValidator<T>
                // Use DefaultValidator<T> instead
                config.For(typeof(IValidator<>)).Add(typeof(DefaultValidator<>));

                //Populate the container using the service collection
                config.Populate(services);
            });

            //Return the IServiceProvider. This tells ASP.NET Core to use StructureMap to resolve dependencies
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
