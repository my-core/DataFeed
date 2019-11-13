
using System;
using System.Collections.Generic;
using System.Text;
using DataFeed.Geography.FeedMonitor.Model.Mongo;
using FastNet.Framework.Mongo;

namespace DataFeed.Geography.FeedMonitor.Repository.Mongodb
{
    public interface IGeographyMongoRepository : IMongoRepository
    {
        List<GeographyModel> GetProvinceList();
    }
}
