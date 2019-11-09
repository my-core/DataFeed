using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.Model.Mongo
{
    /// <summary>
    /// Mongodb基类
    /// </summary>
    public class BaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
