using DataFeed.Geography.Model.Mongo;
using DataFeed.Geography.Service;
using FastNet.Framework.NetCrawler;
using NLog;
using System;
using System.Collections.Generic;

namespace DataFeed.Geography.Crawlers
{
    public class GeographyCrawler : Crawler
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private GeographyService _geographyService;
        public GeographyCrawler(CrawlOptions crawlOptions, GeographyService geographyService) : base(crawlOptions)
        {
            _geographyService = geographyService;
        }

        public void StartRequest()
        {
            string url = "http://www.stats.gov.cn/tjsj/tjbz/tjyqhdmhcxhfdm/2018/index.html";
            _logger.Info($"Request->url{url}");
            Request(url, ParserProvince);
        }
        /// <summary>
        /// 省
        /// </summary>
        /// <param name="e"></param>
        private void ParserProvince(CallbackEventArgs e)
        {
            try
            {
                var htmlDoc = e.HtmlDocument;
                var nodes = htmlDoc.DocumentNode.SelectNodes("//tr[@class='provincetr']/td/a");
                foreach (var node in nodes)
                {
                    string url = node.Attributes["href"].Value;
                    string provinceCode = url.Split('.')[0];
                    string provinceName = node.InnerText.Trim();
                    Dictionary<string, object> metadata = new Dictionary<string, object>();
                    metadata.Add("provinceCode", provinceCode);
                    metadata.Add("provinceName", provinceName);
                    url = e.Url.Substring(0, e.Url.LastIndexOf("/") + 1) + url;
                    _logger.Info($"ParserProvince->url[{url}]");
                    Request(url, ParserProvince, metadata, 1);
                };
            }
            catch(Exception ex)
            {
                _logger.Error(ex, $"ParserCity->{e.Url}");
            }
        }
        /// <summary>
        /// 市
        /// </summary>
        /// <param name="e"></param>
        private void ParserCity(CallbackEventArgs e)
        {
            try
            {
                var htmlDoc = e.HtmlDocument;
                var nodes = htmlDoc.DocumentNode.SelectNodes("//tr[@class='citytr']/td[2]/a");
                foreach (var node in nodes)
                {
                    string url = node.Attributes["href"].Value;
                    string cityCode = url.Split('/')[1].Replace(".html", "").Trim();
                    string cityName = node.InnerText.Trim();
                    Dictionary<string, object> metadata = new Dictionary<string, object>();
                    metadata.Add("provinceCode", e.Metadata["provinceCode"]);
                    metadata.Add("provinceName", e.Metadata["provinceName"]);
                    metadata.Add("cityCode", cityCode);
                    metadata.Add("cityName", cityName);
                    url = e.Url.Substring(0, e.Url.LastIndexOf("/") + 1) + url;
                    _logger.Info($"ParserCity->url[{url}]");
                    //特殊处理
                    if (cityName == "东莞市" || cityName == "中山市")
                    {
                        metadata.Add("countyCode", cityCode + "00");
                        metadata.Add("countyName", "市辖区");
                        Request(url, ParserTown, metadata, 3);
                    }
                    else
                    {
                        Request(url, ParserCounty, metadata, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"ParserCity->{e.Url}");
            }
        }
        /// <summary>
        /// 县/区
        /// </summary>
        /// <param name="e"></param>
        private void ParserCounty(CallbackEventArgs e)
        {
            try
            {
                var htmlDoc = e.HtmlDocument;
                var nodes = htmlDoc.DocumentNode.SelectNodes("//tr[@class='countytr']/td[2]/a");
                foreach (var node in nodes)
                {
                    string url = node.Attributes["href"].Value;
                    string countyCode = url.Split('/')[1].Replace(".html", "").Trim();
                    string countyName = node.InnerText.Trim();
                    Dictionary<string, object> metadata = new Dictionary<string, object>();
                    metadata.Add("provinceCode", e.Metadata["provinceCode"]);
                    metadata.Add("provinceName", e.Metadata["provinceName"]);
                    metadata.Add("cityCode", e.Metadata["cityCode"]);
                    metadata.Add("cityName", e.Metadata["cityName"]);
                    metadata.Add("countyCode", countyCode);
                    metadata.Add("countyName", countyName);
                    url = e.Url.Substring(0, e.Url.LastIndexOf("/") + 1) + url;
                    _logger.Info($"ParserCounty->url[{url}]");
                    Request(url, ParserTown, metadata, 3);
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"ParserCounty->{e.Url}");
            }
        }
        /// <summary>
        /// 镇
        /// </summary>
        /// <param name="e"></param>
        private void ParserTown(CallbackEventArgs e)
        {
            try
            {
                var htmlDoc = e.HtmlDocument;
                var nodes = htmlDoc.DocumentNode.SelectNodes("//tr[@class='towntr']/td[2]/a");
                foreach (var node in nodes)
                {
                    string url = node.Attributes["href"].Value;
                    string townCode = url.Split('/')[1].Replace(".html", "").Trim();
                    string townName = node.InnerText.Trim();
                    Dictionary<string, object> metadata = new Dictionary<string, object>();
                    metadata.Add("provinceCode", e.Metadata["provinceCode"]);
                    metadata.Add("provinceName", e.Metadata["provinceName"]);
                    metadata.Add("cityCode", e.Metadata["cityCode"]);
                    metadata.Add("cityName", e.Metadata["cityName"]);
                    metadata.Add("countyCode", e.Metadata["countyCode"]);
                    metadata.Add("countyName", e.Metadata["countyName"]);
                    metadata.Add("townCode", townCode);
                    metadata.Add("townName", townName);
                    url = e.Url.Substring(0, e.Url.LastIndexOf("/") + 1) + url;
                    _logger.Info($"ParserTown->url[{url}]");
                    Request(url, ParserVillage, metadata, 4);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"ParserTown->{e.Url}");
            }
        }
        /// <summary>
        /// 村
        /// </summary>
        /// <param name="e"></param>
        private void ParserVillage(CallbackEventArgs e)
        {
            try
            {
                var list = new List<GeographyModel>();
                var htmlDoc = e.HtmlDocument;
                var nodes = htmlDoc.DocumentNode.SelectNodes("//tr[@class='villagetr']");
                foreach (var node in nodes)
                {
                    string villageCode = node.SelectSingleNode("td[1]").InnerText.Trim();
                    string villageName = node.SelectSingleNode("td[2]").InnerText.Trim();
                    GeographyModel model = new GeographyModel()
                    {
                        ProvinceCode = e.Metadata["provinceCode"].ToString(),
                        ProvinceName = e.Metadata["provinceName"].ToString(),
                        CityCode = e.Metadata["cityCode"].ToString(),
                        CityName = e.Metadata["cityName"].ToString(),
                        CountyCode = e.Metadata["countyCode"].ToString(),
                        CountyName = e.Metadata["countyName"].ToString(),
                        TownCode = e.Metadata["townCode"].ToString(),
                        TownName = e.Metadata["townName"].ToString(),
                        VillageCode = villageCode,
                        VillageName = villageName
                    };
                    list.Add(model);
                    //string msg = @$"{e.Metadata["provinceName"]}({e.Metadata["provinceCode"]})-{e.Metadata["cityCode"]}({e.Metadata["cityName"]})-{e.Metadata["countyCode"]}({e.Metadata["countyName"]})-{e.Metadata["townCode"]}({e.Metadata["townName"]})-{villageName}({villageCode})";
                    //_logger.Info($"ParserTown->msg{msg}");
                }
                if (list.Count > 0)
                {
                    _geographyService.InsertGeography(list);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"ParserVillage->{e.Url}");
            }
        }
    }
}
