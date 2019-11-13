using DataFeed.Geography.FeedMonitor.Model.Mongo;
using DataFeed.Geography.FeedMonitor.Repository.Mongodb;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.FeedMonitor.Service
{
    public interface IGeographyService
    {
        /// <summary>
        /// 将抓取到数据保存mongodb库
        /// </summary>
        /// <param name="list"></param>
        void InsertGeography(List<GeographyModel> list);

        /// <summary>
        /// 处理数据，清洗抓取数据并保存到mysql库
        /// </summary>
        void HandleGeographyData();
    }
}
