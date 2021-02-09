using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteListMiddlewareActionFilter
{
    public class Startup
    {
        // �p��b�{���̭����appsettings.json�O? ����²��A�ڭ̥u�n�ϥ�IConfiguration�ê`�J�b�غc�l�̭��N�i�H�F�A�Ь�Startup.cs������
        public IConfiguration Configuration { get; }
        //public ILoggerFactory _loggerFactory { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //_loggerFactory = loggerFactory; //Startup �����loggerFactory
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ClientIdCheckFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();


            //�o�O���쪺whitelist method using Middleware
            //app.UseMiddleware<WhiteListMiddleware>(Configuration["Whitelist"]);


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
