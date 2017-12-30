using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Services;

namespace Microsoft.Extensions.DependencyInjection.Services
{
    public static class EmailSenderServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailSender(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddSingleton<NetworkClient>();
            services.AddScoped<MessageFactory>();
            services.AddSingleton(
                new EmailServerSettings
                (
                    host: "smtp.server.com",
                    port: 25
                ));
            return services;
        }
    }
}
