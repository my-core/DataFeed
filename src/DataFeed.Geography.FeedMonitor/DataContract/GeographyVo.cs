using DataFeed.Geography.FeedMonitor.Model.Mongo;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.FeedMonitor.DataContract
{
    public class ProvinceVo
    {
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
    }

    public class CityVo
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }
    }

    public class CountyVo
    {
        public string CountyCode { get; set; }
        public string CountyName { get; set; }
    }

    public class TownVo
    {
        public string TownCode { get; set; }
        public string TownName { get; set; }
    }

    public class VillageVo
    {
        public string VillageCode { get; set; }
        public string VillageName { get; set; }
    }
}
