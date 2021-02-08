using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleAppDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {

                MyApplication app = serviceProvider.GetService<MyApplication>();
                // Start up logic here
                app.Run();
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddLogging(configure => configure.AddConsole())
                    .AddTransient<MyApplication>();
        }

        public class MyApplication
        {
            private readonly ILogger _logger;
            private readonly IHttpContextAccessor _access;
            public MyApplication(ILoggerFactory factory, IHttpContextAccessor access)
            {
                _logger = factory.CreateLogger("myapplication");
                _access = access;
            }

            internal void Run()
            {
                var remoteIp = _access.HttpContext.Connection.RemoteIpAddress;
                Console.WriteLine(remoteIp);

                _logger.LogInformation("Application Started at {dateTime}", DateTime.UtcNow);

                //Business Logic START
                //Business logic END
                _logger.LogInformation("Application Ended at {dateTime}", DateTime.UtcNow);
            }
        }
    }
}
