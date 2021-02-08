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

            //ASP.NET Core ��@�F IHttpContextAccessor�A�� HttpContext �i�H���P���`�J���ݭn�Ψ쪺����ϥΡC
            //�ѩ� IHttpContextAccessor �u�O���� HttpContext ��Ҫ����f�A�� Singleton ���覡�N�i�H�Ѩ䥦����ϥ�
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISessionWrapper, SessionWrapper>();

            // �N Session �s�b ASP.NET Core �O���餤
            //services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.Name = "whatEverYouWant2";
                options.IdleTimeout = TimeSpan.FromMinutes(5); // it will timeout after 5 minutes
            });

            //#�������֨�
            //services.AddDistributedMemoryCache();


            //#�����֨�:
            //�ϥΥ����֨����覡��²��A�u�n�b Startup.ConfigureServices �I�s AddMemoryCache�A�N��z�L�`�J IMemoryCache �ϥΥ����֨��C�p�U
            //services.AddMemoryCache();


            //#�]�w Redis Cache: 
            //�w�˧�����A�N Startup.ConfigureServices ���U���������֨��A�ȡA�q AddDistributedMemoryCache �令 AddDistributedRedisCache �p�U�G
            services.AddDistributedRedisCache(options =>
            {
                // Redis Server �� IP �� Port
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

            // SessionMiddleware �[�J Pipeline
            app.UseSession();

            //app.Run(async (context) =>
            //{
            //    var user = context.Session.GetObject<UserModel>("numberOne");
            //    context.Session.SetObject<UserModel>("numberOne", user);

            //    context.Session.SetString("Sample", "This is Session.");
            //    string message = context.Session.GetString("Sample");
            //    await context.Response.WriteAsync($"{message}");
            //});



            //// SessionMiddleware �[�J Pipeline
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
            //    // �R�� Cookies ���
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
