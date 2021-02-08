using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationWithoutHttps
{
    public class Startup
    {

        // �̿�`�J ����U���U�˪��Ȯ� �|�����K
        public IConfiguration _configuration { get; }

        // IConfiguration Ū���U�ئU�˪��t�m �귽 �H��
        public Startup(IConfiguration configuration) 
        {
            _configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient("client", config =>
            {
                config.BaseAddress = new Uri("https://www.google.com/");
                config.DefaultRequestHeaders.Add("Headerrrr", "clientHeader");
            });

            services.AddMvc();


            //���U SampleClient (��ԥΪk2�G�ϥΦ۩w�q������ HttpClientFactory �ШD) �Ѧ�https://www.itread01.com/content/1564990083.html
            services.AddHttpClient<SampleClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) // ���ҧP�_ �O�_���}�o���� �O���ܤ~�|�i�h
            {
                app.UseDeveloperExceptionPage(); // �եΤ@�ǭ�
            }


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "testingHttp",
                    pattern: "{Controller}/{action}"
                );

                //endpoints.MapGet("/", async context =>
                //{
                //    // var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                //    var configVal = _configuration["Mykey"];
                //    await context.Response.WriteAsync(configVal);
                //});
            });
        }
    }
}
