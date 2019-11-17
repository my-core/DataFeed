using DataFeed.Finance.WebApi.Service;
using FastNet.Framework.NetCrawler;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataFeed.Finance.FeedMonitor.Crawlers
{
    public class GeographyCrawler : Crawler
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private FinanceService _financeService;
        public GeographyCrawler(CrawlOptions crawlOptions, FinanceService financeService) : base(crawlOptions)
        {
            _financeService = financeService;
        }

        public void StartRequest()
        {

            string url = "http://www.stats.gov.cn/tjsj/tjbz/tjyqhdmhcxhfdm/2018/index.html";
            Request(url, ParserStockCompany);
        }
        /// <summary>
        /// 省
        /// </summary>
        /// <param name="e"></param>
        private void ParserStockCompany(CallbackEventArgs e)
        {
            try
            {
                _logger.Info($"ParserStockCompany->url[{e.Url}]");
                var htmlDoc = e.HtmlDocument;
                var nodes = htmlDoc.DocumentNode.SelectNodes("//tr[@class='provincetr']/td/a");
                if (nodes == null)
                {
                    _logger.Warn($"ParserStockCompany->can't find nodes for {e.Url}");
                    Request(e.Url, ParserStockCompany, e.Metadata);
                    return;
                }
                foreach (var node in nodes)
                {
                    string url = node.Attributes["href"].Value;
                    string provinceCode = url.Split('.')[0];
                    string provinceName = node.InnerText.Trim();
                    Dictionary<string, object> metadata = new Dictionary<string, object>();
                    metadata.Add("provinceCode", provinceCode);
                    metadata.Add("provinceName", provinceName);
                    url = e.Url.Substring(0, e.Url.LastIndexOf("/") + 1) + url;
                };
            }
            catch(Exception ex)
            {
                _logger.Error(ex, $"ParserStockCompany->{e.Url}");
            }
        }
    }
}
