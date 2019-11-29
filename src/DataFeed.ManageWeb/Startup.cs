using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataFeed.ManageWeb.Application.Filter;
using DataFeed.ManageWeb.Application.Middleware;
using DataFeed.ManageWeb.Repository;
using DataFeed.ManageWeb.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace DataFeed.ManageWeb
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
            //db connstring
            string baseDBConnString = Configuration.GetConnectionString("BaseDB");
            string datafeedDBConnString = Configuration.GetConnectionString("DatafeedDB");
            //repositoty
            services.AddSingleton<ISystemRepository>(new SystemRepository(baseDBConnString));
            services.AddSingleton<IFinanceRepository>(new FinanceRepository(datafeedDBConnString));
            //service
            services.AddSingleton<ISystemService, SystemService>();
            services.AddSingleton<IFinanceService, FinanceService>();
            //�����֤Cookie��Ϣ
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Login";
            });
            // mvc action�����ģ���taghelper(LayuiPagerTagHelper.cs)��չ���õ�
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews(options =>
            {
                //ȫ��������
                options.Filters.Add(typeof(GlobalActionFilterAttribute));
                //ȫ���쳣����
                options.Filters.Add(typeof(GlobalExceptionFilterAttribute));
            })
            .AddNewtonsoftJson(options =>
            {
                //���ͬ������
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //ʱ���ʽ
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuth();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
