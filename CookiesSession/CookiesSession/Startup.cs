using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookiesSession.Extensions;
using CookiesSession.Wrappers;

namespace CookiesSession
{
    public class UserModel
    {
        public string name { get; set; } = "john";
        public int Age { get; set; } = 5;
    }
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();

            //ASP.NET Core 實作了 IHttpContextAccessor，讓 HttpContext 可以輕鬆的注入給需要用到的物件使用。
            //由於 IHttpContextAccessor 只是取用 HttpContext 實例的接口，用 Singleton 的方式就可以供其它物件使用
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISessionWrapper, SessionWrapper>();

            // 將 Session 存在 ASP.NET Core 記憶體中
            //services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.Name = "whatEverYouWant2";
                options.IdleTimeout = TimeSpan.FromMinutes(5); // it will timeout after 5 minutes
            });

            //#分散式快取
            //services.AddDistributedMemoryCache();


            //#本機快取:
            //使用本機快取的方式很簡單，只要在 Startup.ConfigureServices 呼叫 AddMemoryCache，就能透過注入 IMemoryCache 使用本機快取。如下
            //services.AddMemoryCache();


            //#設定 Redis Cache: 
            //安裝完成後，將 Startup.ConfigureServices 註冊的分散式快取服務，從 AddDistributedMemoryCache 改成 AddDistributedRedisCache 如下：
            services.AddDistributedRedisCache(options =>
            {
                // Redis Server 的 IP 跟 Port
                options.Configuration = "127.0.0.1:6379";
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // SessionMiddleware 加入 Pipeline
            app.UseSession();

            //app.Run(async (context) =>
            //{
            //    var user = context.Session.GetObject<UserModel>("numberOne");
            //    context.Session.SetObject<UserModel>("numberOne", user);

            //    context.Session.SetString("Sample", "This is Session.");
            //    string message = context.Session.GetString("Sample");
            //    await context.Response.WriteAsync($"{message}");
            //});



            //// SessionMiddleware 加入 Pipeline
            //app.UseSession();

            //app.Run(async (context) =>
            //{
            //    context.Session.SetString("SampleSession", "This is Session.");
            //    string message = context.Session.GetString("SampleSession");
            //    await context.Response.WriteAsync($"{message}");
            //});


            //// cookie
            //app.Run(async (context) =>
            //{
            //    string message;

            //    if (!context.Request.Cookies.TryGetValue("Sample", out message))
            //    {
            //        message = "Save data to cookies";
            //    }
            //    context.Response.Cookies.Append("Sample", "This is Cookies");
            //    // 刪除 Cookies 資料
            //    //context.Response.Cookies.Delete("Sample");

            //    await context.Response.WriteAsync($"{message}");
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                        name: "testing",
                        pattern: "{controller}/{action}"
                    );

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
