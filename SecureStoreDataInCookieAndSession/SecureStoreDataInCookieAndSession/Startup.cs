using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecureStoreDataInCookieAndSession.Models;

namespace SecureStoreDataInCookieAndSession
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();

            services.AddSingleton<IServiceModel, ServiceModel>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // 將 Session 存在 ASP.NET Core 記憶體中
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; //限制只有在 HTTPS 連線的情況下，才允許使用 Session。如此一來變成加密連線，就不容易被攔截。
                options.Cookie.Name = "My_SecureStoreDataInCookieAndSession_test"; //沒必要將 Server 或網站技術的資訊爆露在外面，所以預設 Session 名稱 .AspNetCore.Session 可以改掉。
                options.IdleTimeout = TimeSpan.FromMinutes(5); //修改合理的 Session 到期時間。預設是 20 分鐘沒有跟 Server 互動的 Request，就會將 Session 變成過期狀態。(20分鐘有點長，不過還是要看產品需求。)
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
                endpoints.MapControllers();
            });
        }
    }
}
