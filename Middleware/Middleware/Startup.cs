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
            // 一個簡單的 Middleware 範例。Startup.cs 如下：
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

            // Middleware 也可以作為攔截使用，Startup.cs 如下：
            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("First Middleware in. \r\n");
            //     await next.Invoke();
            //     await context.Response.WriteAsync("First Middleware out. \r\n");
            // });

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("Second Middleware in. \r\n");

            //     // 水管阻塞，封包不往後送
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



            //// App.Map (Map 是能用來處理一些簡單路由的 Middleware，可依照不同的 URL 指向不同的 Run 及註冊不同的 Use)  use dotnet run and use URL "http://localhost:5000/second"
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



            //// 全域註冊  --  在 Startup.cs 的 Configure 註冊 Middleware 就可以套用到所有的 Request。如下：
            // app.UseMiddleware<FirstMiddleware>();

            // app.Run(async context => 
            // {
            //     await context.Response.WriteAsync("hello ~~ @ \r\n");
            // });


            //// 區域註冊 --  Middleware 也可以只套用在特定的 Controller 或 Action。註冊方式如 Controllers\HomeController.cs：



            //// Extensions --
            //大部分擴充的 Middleware 都會用一個靜態方法包裝，如：UseRouting()、UseRewriter()等。
            // 自製的 Middleware 當然也可以透過靜態方法包，範例 CustomMiddlewareExtensions.cs 如下：
            // 註冊 Extension Middleware 的方式如下：
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
