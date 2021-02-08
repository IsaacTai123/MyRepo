using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName;

namespace ExceptionHandler
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // �Ȯɴ��եi�H�����������ҦW��
            env.EnvironmentName = EnvironmentName.Development;
            if (env.IsDevelopment()) //�o�ӬO�q ASPNETCORE_ENVIRONMENT �ӨӡC�i�H�� https://blog.johnwu.cc/article/ironman-day16-asp-net-core-multiple-environments.html �o�g
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //app.UseMiddleware<ExceptionMiddleware>();
            //app.UseExceptionHandler("/error");
            //app.UseExceptionHandler(new ExceptionHandlerOptions()
            //{
            //    ExceptionHandler = async context =>
            //    {
            //        bool isApi = Regex.IsMatch(context.Request.Path.Value, "^/api/", RegexOptions.IgnoreCase); //IgnoreCase: �O�ǰt�����j�p�g �w�]���p�Ϥ��j�p�g
            //        if (isApi) //if isApi is true
            //        {
            //            context.Response.ContentType = "application/json";
            //            var json = @"{ ""Message"": ""Internal Server Error"" }";
            //            await context.Response.WriteAsync(json);
            //            return;
            //        }
            //        context.Response.Redirect("/error");
            //    }
            //});


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "path",
                    pattern: "{controller=Home}/{action=Index}");
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
