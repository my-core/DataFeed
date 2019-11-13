
using DataFeed.Geography.FeedMonitor.Crawlers;
using DataFeed.Geography.FeedMonitor.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataFeed.Geography.FeedMonitor.Quartz
{
    /// <summary>
    /// Quartz定时调度服务
    /// </summary>
    public class GeographyHostedService : IHostedService
    {
        private ILogger<GeographyHostedService> _logger;
        private GeographyCrawler _crawler;
        private IGeographyService _geographyService;
        public GeographyHostedService(ILogger<GeographyHostedService> logger, GeographyCrawler crawler, IGeographyService geographyService)
        {
            _logger = logger;
            _crawler = crawler;
            _geographyService = geographyService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("QuartzService start");

            //同上国家统计局的省市区镇乡数据
            //_crawler.StartRequest();

            //处理数据，清洗抓取的省市区镇乡数据并保存到mysql库
            _geographyService.HandleGeographyData();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("QuartzService stop");
            return Task.CompletedTask;
        }        
       
    }
}
