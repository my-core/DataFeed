
using AutoMapper;
using DataFeed.Geography.WebApi.Repository;
using DataFeed.Geography.WebApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataFeed.Geography.WebApi
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
            //db connection string
            //string mongoConnString = Configuration.GetConnectionString("MongoDB");
            string datafeedConnString = Configuration.GetConnectionString("DataFeedDB");
            //repository
            //services.AddSingleton<IGeographyM1ongoRepository>(new GeographyMongoRepository(mongoConnString, "DataFeed"));
            services.AddSingleton(new GeographyRepository(datafeedConnString));
            //service
            services.AddTransient<GeographyService>();
            //automapper
            services.AddAutoMapper(typeof(Startup));
            //swagger
            services.ConfigureSwaggerServices(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();            
            app.UseAuthorization();    
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{Configuration["SwaggerService:Version"]}/swagger.json", "Geography.WebApi V1");
            });
        }
    }
}
