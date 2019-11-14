
using System;
using System.Collections.Generic;
using System.Text;
using DataFeed.Geography.FeedMonitor.DataContract;
using DataFeed.Geography.FeedMonitor.Model.Mongo;
using FastNet.Framework.Mongo;

namespace DataFeed.Geography.FeedMonitor.Repository.Mongodb
{
    public interface IGeographyMongoRepository : IMongoRepository
    {
        /// <summary>
        /// 查询省，去重
        /// </summary>
        /// <returns></returns>
        List<ProvinceVo> GetProvinceList();
        /// <summary>
        /// 查询市
        /// </summary>
        /// <returns></returns>
        List<CityVo> GetCityList(string provinceCode);
        /// <summary>
        /// 查询区
        /// </summary>
        /// <returns></returns>
        List<CountyVo> GetCountyList(string cityCode);
        /// <summary>
        /// 查询镇
        /// </summary>
        /// <returns></returns>
        List<TownVo> GetTownList(string countyCode);
        /// <summary>
        /// 查询乡
        /// </summary>
        /// <returns></returns>
        List<VillageVo> GetVillageList(string townCode);
        /// <summary>
        /// 查询所有数据(指定列)
        /// </summary>
        /// <returns></returns>
        List<ResultT> List<T, ResultT>();
    }
}
