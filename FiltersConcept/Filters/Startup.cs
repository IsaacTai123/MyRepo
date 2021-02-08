using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc(configure =>
            {
                configure.Filters.Add(new ResultFilter());
                configure.Filters.Add(new ExceptionFilter());
                configure.Filters.Add(new ResourceFilter());

                //configure.Filters.Add(new AddHeaderAttribute("Author", "Rick Anderson")); //不知道為啥麼錯誤 無法加入header , response has already started
                //configure.Filters.Add(new ActionFilter() { Name = "Global", Order = 3 }); //更改順序 用IOrderedFilter
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                endpoints.MapControllerRoute(
                    name: "filter",
                    pattern: "{controller=Home}/{action=Index}"
                    );
            });
        }
    }
}
