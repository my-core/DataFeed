
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FastNet.Framework.Mongo;

using MongoDB.Driver;

namespace DataFeed.Geography.Repository.Mongodb
{
    public class GeographyMongoRepository : MongoRepository, IGeographyMongoRepository
    {
        public GeographyMongoRepository(string connString, string dbName) 
            : base(connString, dbName) { }

        
    }
}
