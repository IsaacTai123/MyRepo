using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // �@��²�檺 Middleware �d�ҡCStartup.cs �p�U�G
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("First Middleware in. \r\n");
                await next();
                await context.Response.WriteAsync("First Middleware out. \r\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Second Middleware in. \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Second Middleware out. \r\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Third Middleware in. \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Third Middleware out. \r\n");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World! \r\n");
            });

            // Middleware �]�i�H�@���d�I�ϥΡAStartup.cs �p�U�G
            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("First Middleware in. \r\n");
            //     await next.Invoke();
            //     await context.Response.WriteAsync("First Middleware out. \r\n");
            // });

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("Second Middleware in. \r\n");

            //     // ���ު���A�ʥ]������e
            //     var condition = false;
            //     if(condition) {
            //         await next.Invoke();
            //     }

            //     await context.Response.WriteAsync("Second Middleware out. \r\n");
            // });

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("Third Middleware in. \r\n");
            //     await next.Invoke();
            //     await context.Response.WriteAsync("Third Middleware out. \r\n");
            // });

            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Hello World! \r\n");
            // });



            //// App.Map (Map �O��ΨӳB�z�@��²����Ѫ� Middleware�A�i�̷Ӥ��P�� URL ���V���P�� Run �ε��U���P�� Use)  use dotnet run and use URL "http://localhost:5000/second"
            // app.Use(async (context, next) => 
            // {
            //     await context.Response.WriteAsync("First Middleware in \r\n");
            //     await next.Invoke();
            //     await context.Response.WriteAsync("First Middleware out \r\n");
            // });

            // app.Map("/second", mapApp =>
            // {
            //     mapApp.Use(async (context, next) => 
            //     {
            //         await context.Response.WriteAsync("Second Middleware in \r\n");
            //         await next.Invoke();
            //         await context.Response.WriteAsync("Second Middleware out \r\n");
            //     });
            //     mapApp.Run(async context => 
            //     {
            //         await context.Response.WriteAsync("second \r\n");
            //     });
            // });

            // app.Run(async context => 
            // {
            //     await context.Response.WriteAsync("Hello World! \r\n");
            // });



            //// ������U  --  �b Startup.cs �� Configure ���U Middleware �N�i�H�M�Ψ�Ҧ��� Request�C�p�U�G
            // app.UseMiddleware<FirstMiddleware>();

            // app.Run(async context => 
            // {
            //     await context.Response.WriteAsync("hello ~~ @ \r\n");
            // });


            //// �ϰ���U --  Middleware �]�i�H�u�M�Φb�S�w�� Controller �� Action�C���U�覡�p Controllers\HomeController.cs�G



            //// Extensions --
            //�j�����X�R�� Middleware ���|�Τ@���R�A��k�]�ˡA�p�GUseRouting()�BUseRewriter()���C
            // �ۻs�� Middleware ��M�]�i�H�z�L�R�A��k�]�A�d�� CustomMiddlewareExtensions.cs �p�U�G
            // ���U Extension Middleware ���覡�p�U�G
            // app.UseFirstMiddleware();

            // app.Run(async context => 
            // {
            //     await context.Response.WriteAsync("Hello !!! \r\n");
            // });


            // app.UseMiddleware<FirstMiddleRequestResponse>();
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Request !!! \r\n");
            // });


            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path == "/darkthread")
            //        await context.Response.WriteAsync("ASP.NET Core Rocks!");
            //    else
            //    {
            //        await next();
            //        await context.Response.WriteAsync(" Powered by ASP.NET Core");
            //    }
            //});

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseStaticFiles();
            //app.UseFirstMiddleware();
            ////app.Run(async context =>
            ////{
            ////    await context.Response.WriteAsync("hello \r\n");
            ////});
            //app.UseRouting();
            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //    endpoints.MapGet("/darkthread", async context =>
            //    {
            //        await context.Response.WriteAsync("Handled by UseEndpoints");
            //    });
            //});
        }
    }
}
