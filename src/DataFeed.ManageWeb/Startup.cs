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
            string baseDBConnString = Configuration.GetConnectionString("BaseDB");
            services.AddSingleton<ISystemRepository>(new SystemRepository(baseDBConnString));
            services.AddSingleton<ISystemService, SystemService>();
            //添加认证Cookie信息
            services.AddAuthentication(options =>
            {
                //DefaultSignInScheme, DefaultSignOutScheme, DefaultChallengeScheme, DefaultForbidScheme 等都会使用该 Scheme 作为默认值。
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            //用来注册 CookieAuthenticationHandler，由它来完成身份认证的主要逻辑。
            .AddCookie(options =>
            {
                // 在这里可以根据需要添加一些Cookie认证相关的配置，在本次示例中使用默认值就可以了。
                options.LoginPath = "/Login";
            });
            // mvc action上下文，在taghelper(LayuiPagerTagHelper.cs)扩展里用到
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews(options =>
            {
                //全局请求处理
                options.Filters.Add(typeof(GlobalActionFilterAttribute));
                //全局异常处理
                options.Filters.Add(typeof(GlobalExceptionFilterAttribute));
            })
            .AddNewtonsoftJson(options =>
            {
                //输出同属性名
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //时间格式
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
