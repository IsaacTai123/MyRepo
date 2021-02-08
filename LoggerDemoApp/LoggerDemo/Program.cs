using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // this is how you use the logger when you're in main method
            var logger = host.Services.GetRequiredService<ILogger<Program>>(); // ask the dependency injection system for a service and that services has ILogger
            logger.LogInformation("The application has started");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) => 
                {
                    // with this i can now change my configuration for my logging
                    logging.ClearProviders(); // means clear out everybody that's listening for logging events, clear out what microsoft has done for us
                    logging.AddConfiguration(context.Configuration.GetSection("Logging")); // we are getthing the section of appsettings.json
                    //logging.AddDebug(); //這個AddDebug 是說我要把這個log顯示在Debug的視窗裡, 下面的Addconsole就是要顯示在console裡
                    logging.AddConsole(); // EventSource, EventLog, TraceSource, AzureAppServicesFile, AzureAppServicesBlob, ApplicationInsights
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                webBuilder.UseStartup<Startup>();
                });
        }
    }
}
