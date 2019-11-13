using DataFeed.Geography.FeedMonitor.Model.Mongo;
using DataFeed.Geography.FeedMonitor.Repository.Mongodb;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataFeed.Geography.FeedMonitor.Service
{
    public class GeographyService : IGeographyService
    {
        private ILogger<GeographyService> _logger;
        private IGeographyMongoRepository _geographyMongoRepository;
        private IGeographyRepository _geographyRepository;
        public GeographyService(ILogger<GeographyService> logger, IGeographyMongoRepository geographyMongoRepository, IGeographyRepository geographyRepository)
        {
            _logger = logger;
            _geographyMongoRepository = geographyMongoRepository;
            _geographyRepository = geographyRepository;
        }

        /// <summary>
        /// 将抓取到数据保存mongodb库
        /// </summary>
        /// <param name="list"></param>
        public void InsertGeography(List<GeographyModel> list)
        {
            _geographyMongoRepository.Insert(list);
        }

        /// <summary>
        /// 处理数据，清洗抓取数据并保存到mysql库
        /// </summary>
        public void HandleGeographyData()
        {
            var result = _geographyMongoRepository.GetProvinceList();
            var provinces = result.GroupBy(a => a.ProvinceCode).Select(g => g.First()).ToList();
        }

        /// <summary>
        /// 省
        /// </summary>
        private void HandleProvinceData()
        {

        }

        /// <summary>
        /// 市
        /// </summary>
        private void HandleCityData()
        {

        }

        /// <summary>
        /// 区
        /// </summary>
        private void HandleCountyData()
        {

        }

        /// <summary>
        /// 镇
        /// </summary>
        private void HandleTownData()
        {

        }

        /// <summary>
        /// 乡
        /// </summary>
        private void HandleVillageData()
        {

        }
    }
}
