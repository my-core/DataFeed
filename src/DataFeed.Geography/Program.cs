
using System.Text;
using DataFeed.Geography.Crawlers;
using DataFeed.Geography.Quartz;
using DataFeed.Geography.Repository.Mongodb;
using DataFeed.Geography.Service;
using FastNet.Framework.NetCrawler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;

namespace DataFeed.Geography
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    NLog.LogManager.LoadConfiguration("nlog.config");
                    //utf-8 support
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    //crawler
                    services.AddSingleton<GeographyCrawler>();
                    services.AddSingleton(new CrawlOptions { MaxCrawlThread = 10 });
                    //db connection string
                    string mongoConnString = hostContext.Configuration.GetConnectionString("MongoDB");
                    //repository
                    services.AddSingleton<IGeographyMongoRepository>(new GeographyMongoRepository(mongoConnString, "DataFeed"));
                    //service
                    services.AddSingleton<IGeographyService, GeographyService>();
                    services.AddHostedService<GeographyHostedService>();
                }).ConfigureLogging((logging, builder) =>
                {
                    builder.AddNLog();
                })
                .UseConsoleLifetime();
    }

    
}
