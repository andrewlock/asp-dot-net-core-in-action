using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KestrelWithHttps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        //Create a customIWebHostBuilder
        public static IWebHost BuildWebHost(string[] args)
        {
            var hostingConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json")
                .Build();

            return WebHost.CreateDefaultBuilder()
                 .UseKestrel(options =>
                 {
                     // Configure the Url and ports to bind to. (http://localhost:5001/api/values)
                     // This overrides calls to UseUrls and the ASPNETCORE_URLS environment variable, but will be 
                     // overriden if you call UseIisIntegration and host behind IIS/IIS Express
                     // You'll see a warning in the console logs
                     options.Listen(IPAddress.Loopback, 5001);

                     options.Listen(IPAddress.Loopback, 5002, listenOptions =>
                    {
                        //Note, you _must_ include a password
                        listenOptions.UseHttps("localhost.pfx", "testpassword");
                    });

                     // Load urls, ports and cert details from configuration
                     var address = IPAddress.Parse(hostingConfig["KestrelAddress"]);
                     var port = int.Parse(hostingConfig["KestrelPort"]);
                     var cert = hostingConfig["CertificateFileName"];
                     var password = hostingConfig["CertificatePassword"];
                     options.Listen(address, port, listenOptions =>
                     {
                         listenOptions.UseHttps(cert, password);
                     });

                     var certificateFromStore = GetSslCertificate();
                     if (certificateFromStore != null)
                     {
                         options.Listen(IPAddress.Loopback, 5004, listenOptions =>
                         {
                             listenOptions.UseHttps(certificateFromStore);
                         });
                     }
                 })
                 .UseStartup<Startup>()
                 .Build();
        }

        private static X509Certificate2 GetSslCertificate()
        {
            //this code only works on Windows
            //try
            //{
            //    // Looks for a certifcate for localhost in the local computer
            //    var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            //    store.Open(OpenFlags.ReadOnly);
            //    var certs = store.Certificates.Find(X509FindType.FindBySubjectName, "localhost", false);
            //    // Look for our cert!
            //    foreach (var cert in certs)
            //    {
            //        if (cert.FriendlyName == "ASP.NET Core Development")
            //        {
            //            store.Close();
            //            return cert;
            //        }
            //    }
            //    store.Close();
            //}
            //catch(PlatformNotSupportedException)
            //{
            //    // can't use this on Linux
            //}
            
            //could not find the certificate
            return null;
        }
    }
}
