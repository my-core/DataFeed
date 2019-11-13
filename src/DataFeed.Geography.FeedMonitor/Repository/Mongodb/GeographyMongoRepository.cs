
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FastNet.Framework.Mongo;

using MongoDB.Driver;
using DataFeed.Geography.FeedMonitor.Model.Mongo;
using MongoDB.Bson;

namespace DataFeed.Geography.FeedMonitor.Repository.Mongodb
{
    public class GeographyMongoRepository : MongoRepository, IGeographyMongoRepository
    {
        public GeographyMongoRepository(string connString, string dbName) 
            : base(connString, dbName) { }

        public List<GeographyModel> GetProvinceList()
        {

             var project= Builders<GeographyModel>.Projection.Include(a => a.ProvinceCode);
            project.Include(a => a.ProvinceName);
            var filter = new BsonDocument();
            var collection = database.GetCollection<GeographyModel>(typeof(GeographyModel).Name);
            return collection.Find(filter).Project<GeographyModel>(project).ToList();
        }
    }
}
