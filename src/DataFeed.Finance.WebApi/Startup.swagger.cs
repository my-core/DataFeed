using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Collections.Generic;

namespace DataFeed.Finance.WebApi
{
    /// <summary>
    /// StartupExtensions
    /// </summary>
    public static partial class StartupExtensions
    {
        /// <summary>
        /// https://www.cnblogs.com/taotaozhuanyong/p/11602820.html
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureSwaggerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(configuration["SwaggerService:Version"], new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = configuration["SwaggerService:Title"],
                    Version = configuration["SwaggerService:Version"],
                    Description = configuration["SwaggerService:Description"],
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = configuration["SwaggerService:Contact:Name"],
                        Email = configuration["SwaggerService:Contact:Email"]
                    }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlSection = configuration.GetSection("SwaggerService:XmlFile");
                List<string> xmlPathList = xmlSection.Get<List<string>>();
                xmlPathList.ForEach(item =>
                {
                    s.IncludeXmlComments(Path.Combine(basePath, item));
                });
            });
        }
    }
}
