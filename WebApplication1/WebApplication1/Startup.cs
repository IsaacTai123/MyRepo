using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttributeRouting.Data;
using Microsoft.EntityFrameworkCore;

namespace AttributeRouting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlDataContractSerializerFormatters();
            //services.AddControllersWithViews();

            //services.AddDbContext<MvcMovieContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("MvcMovieContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // app.UseMvc(); // Using 'UseMvc' to configure MVC is not supported while using Endpoint Routing

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllers();

            });
            // 'EndpointRoutingMiddleware matches endpoints setup by EndpointMiddleware and so must be added to the request execution pipeline before EndpointMiddleware. 
            //Please add EndpointRoutingMiddleware by calling 'IApplicationBuilder.UseRouting' inside the call to 'Configure(...)' in the application startup code.'
        }
    }
}
