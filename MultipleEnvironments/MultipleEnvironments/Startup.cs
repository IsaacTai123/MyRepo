using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnvironmentName = Microsoft.Extensions.Hosting.EnvironmentName;

namespace MultipleEnvironments
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = EnvironmentName.Development;

            if (env.IsDevelopment()) // �o�ӬO�q ASPNETCORE_ENVIRONMENT �Ө�, �P�_�O�_��Development
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(
            //    $"EnvironmentName: {env.EnvironmentName}\r\n"
            //    + $"IsDevelopment: {env.IsDevelopment()}"
            //    );
            //});


            //�ۭq�@�� Test �����ҡC�p�U�G
            env.EnvironmentName = "Test";

            if (env.IsDevelopment())
            {
                // Do something...
            }
            else if (env.IsEnvironment("test"))
            {
                // Do something...
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $"EnvironmentName: {env.EnvironmentName}\r\n"
                  + $"This is test environment: {env.IsEnvironment("test")}");
            });

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
