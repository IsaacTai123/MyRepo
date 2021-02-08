using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SellingSystem.Models.DataModels;
using SellingSystem.Models.DB;
using SellingSystem.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingSystem
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddTransient<IMemberServicers, MemberServicers>();
            services.AddScoped<IMemberModel, MemberModel>();
            services.AddScoped<IMathematics, Mathematics>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // when we are running this application in an development enviroment we will always use developer friendly exception pages
            }


            // https://stackoverflow.com/questions/30755827/getting-absolute-urls-using-asp-net-core
            // You could probably come up with different ways of getting the IHttpContextAccessor in your extension class, but if you want to keep your methods as extension methods in the 
            //end you will need to inject the IHttpContextAccessor into your static class. (Otherwise you will need the IHttpContext as an argument on each call)
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            Extension.Configure(httpContextAccessor);



            app.UseHttpsRedirection();
            app.UseAuthentication();
            
            // app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //endpoints.MapControllerRoute(
                //    name: "loginsuccess",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
                
            });
        }
    }
}
