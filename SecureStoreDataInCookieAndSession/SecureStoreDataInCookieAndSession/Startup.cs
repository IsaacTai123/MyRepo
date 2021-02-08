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

            // �N Session �s�b ASP.NET Core �O���餤
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; //����u���b HTTPS �s�u�����p�U�A�~���\�ϥ� Session�C�p���@���ܦ��[�K�s�u�A�N���e���Q�d�I�C
                options.Cookie.Name = "My_SecureStoreDataInCookieAndSession_test"; //�S���n�N Server �κ����޳N����T�z�S�b�~���A�ҥH�w�] Session �W�� .AspNetCore.Session �i�H�ﱼ�C
                options.IdleTimeout = TimeSpan.FromMinutes(5); //�ק�X�z�� Session ����ɶ��C�w�]�O 20 �����S���� Server ���ʪ� Request�A�N�|�N Session �ܦ��L�����A�C(20�������I���A���L�٬O�n�ݲ��~�ݨD�C)
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
