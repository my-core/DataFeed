using DataFeed.Geography.FeedMonitor.DataContract;
using DataFeed.Geography.FeedMonitor.Model.Mongo;
using DataFeed.Geography.FeedMonitor.Repository.Mongodb;
using DataFeed.Geography.FeedMonitor.Utils;
using DataFeed.Framework.Model;
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
            try
            {
                HandleProvinceData();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "HandleGeographyData");
            }
        }

        /// <summary>
        /// 省
        /// </summary>
        private void HandleProvinceData()
        {
            var result = _geographyMongoRepository.GetProvinceList();
            List<ProvinceInfo> list = new List<ProvinceInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.ProvinceName);
                list.Add(new ProvinceInfo
                {
                    ProvinceCode = item.ProvinceCode,
                    ProvinceName = item.ProvinceName,
                    ShorName = GeoUtils.GetShortName(item.ProvinceName),
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
                HandleCityData(item.ProvinceCode);
            });
            if (list.Count > 0)
                _geographyRepository.Insert(list);
        }

        /// <summary>
        /// 市
        /// </summary>
        private void HandleCityData(string provinceCode)
        {
            List<CityVo> result = _geographyMongoRepository.GetCityList(provinceCode);
            List<CityInfo> list = new List<CityInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.CityName);
                list.Add(new CityInfo
                {
                    ProvinceCode = provinceCode,
                    CityCode = item.CityCode,
                    CityName = item.CityName,
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
                HandleCountyData(item.CityCode);
            });
            if (list.Count > 0)
                _geographyRepository.Insert(list);
        }

        /// <summary>
        /// 区
        /// </summary>
        private void HandleCountyData(string cityCode)
        {
            List<CountyVo> result = _geographyMongoRepository.GetCountyList(cityCode);
            List<CountyInfo> list = new List<CountyInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.CountyName);
                list.Add(new CountyInfo
                {
                    CityCode = cityCode,
                    CountyCode = item.CountyCode,
                    CountyName = item.CountyName,
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
                HandleTownData(item.CountyCode);
            });
            if (list.Count > 0)
                _geographyRepository.Insert(list);
        }

        /// <summary>
        /// 镇
        /// </summary>
        private void HandleTownData(string countyCode)
        {
            List<TownVo> result = _geographyMongoRepository.GetTownList(countyCode);
            List<TownInfo> list = new List<TownInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.TownName);
                list.Add(new TownInfo
                {
                    CountyCode = countyCode,
                    TownCode = item.TownCode,
                    TownName = item.TownName,
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
                HandleVillageData(item.TownCode);
            });
            if (list.Count > 0)
                _geographyRepository.Insert(list);
        }

        /// <summary>
        /// 乡
        /// </summary>
        private void HandleVillageData(string townCode)
        {
            List<VillageVo> result = _geographyMongoRepository.GetVillageList(townCode);
            List<VillageInfo> list = new List<VillageInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.VillageName);
                list.Add(new VillageInfo
                {
                    TownCode = townCode,
                    VillageCode = item.VillageCode,
                    VillageName = item.VillageName,
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
            });
            if (list.Count > 0)
                _geographyRepository.Insert(list);
        }

        /// <summary>
        /// 获取全拼并将首字母大写
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string GetSpell(string text)
        {
            string ret = string.Empty;
            string spell = NPinyin.Pinyin.GetPinyin(text);
            var spellArr = spell.Split(' ').ToList();
            spellArr.ForEach(item =>
            {
                ret += item.Substring(0, 1).ToUpper() + item.Substring(1);
            });
            return ret;
        }
    }
}
