
using DataFeed.Geography.Crawlers;
using DataFeed.Geography.Quartz.Job;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataFeed.Geography.Quartz
{
    /// <summary>
    /// Quartz定时调度服务
    /// </summary>
    public class GeographyHostedService : IHostedService
    {
        private ILogger<GeographyHostedService> _logger;
        private GeographyCrawler _crawler;
        public GeographyHostedService(ILogger<GeographyHostedService> logger, GeographyCrawler crawler)
        {
            _logger = logger;
            _crawler = crawler;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("QuartzService start");
            _crawler.StartRequest();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("QuartzService stop");
            return Task.CompletedTask;
        }        
       
    }
}
