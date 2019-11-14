
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FastNet.Framework.Mongo;

using MongoDB.Driver;
using DataFeed.Geography.FeedMonitor.Model.Mongo;
using MongoDB.Bson;
using DataFeed.Geography.FeedMonitor.DataContract;
using Newtonsoft.Json;

namespace DataFeed.Geography.FeedMonitor.Repository.Mongodb
{
    public class GeographyMongoRepository : MongoRepository, IGeographyMongoRepository
    {
        public GeographyMongoRepository(string connString, string dbName) 
            : base(connString, dbName) { }


        /// <summary>
        /// 查询省，去重
        /// </summary>
        /// <param name="pipeline"></param>
        /// <returns></returns>
        public List<ProvinceVo> GetProvinceList()
        {
            var result = new List<ProvinceVo>();
            string groupPipeline = @"{'$group':{'_id':{'ProvinceCode':'$ProvinceCode','ProvinceName':'$ProvinceName'}}}";

            IList<IPipelineStageDefinition> stages = new List<IPipelineStageDefinition>();
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(groupPipeline));
            var pipeline = new PipelineStagePipelineDefinition<BsonDocument, BsonDocument>(stages);

            var collection = database.GetCollection<BsonDocument>(typeof(GeographyModel).Name);
            var list = collection.Aggregate(pipeline).ToList();
            list.ForEach(item =>
            {
                result.Add(JsonConvert.DeserializeObject<ProvinceVo>(item.GetValue("_id").ToJson()));
            });
            return result.OrderBy(a => a.ProvinceCode).ToList();
        }
        /// <summary>
        /// 查询市
        /// </summary>
        /// <returns></returns>
        public List<CityVo> GetCityList(string provinceCode)
        {
            var result = new List<CityVo>();
            string matchPipeline = @"{'$match':{'ProvinceCode':'" + provinceCode + "'}}";
            string groupPipeline = @"{'$group':{'_id':{'CityCode':'$CityCode','CityName':'$CityName'}}}";

            IList<IPipelineStageDefinition> stages = new List<IPipelineStageDefinition>();
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(matchPipeline));
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(groupPipeline));
            var pipeline = new PipelineStagePipelineDefinition<BsonDocument, BsonDocument>(stages);

            var collection = database.GetCollection<BsonDocument>(typeof(GeographyModel).Name);
            var list = collection.Aggregate(pipeline).ToList();
            list.ForEach(item =>
            {
                result.Add(JsonConvert.DeserializeObject<CityVo>(item.GetValue("_id").ToJson()));
            });
            return result.OrderBy(a => a.CityCode).ToList();
        }
        /// <summary>
        /// 查询区
        /// </summary>
        /// <returns></returns>
        public List<CountyVo> GetCountyList(string cityCode)
        {
            var result = new List<CountyVo>();
            string matchPipeline = @"{'$match':{'CityCode':'" + cityCode + "'}}";
            string groupPipeline = @"{'$group':{'_id':{'CountyCode':'$CountyCode','CountyName':'$CountyName'}}}";            

            IList<IPipelineStageDefinition> stages = new List<IPipelineStageDefinition>();
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(matchPipeline));
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(groupPipeline));
            var pipeline = new PipelineStagePipelineDefinition<BsonDocument, BsonDocument>(stages);

            var collection = database.GetCollection<BsonDocument>(typeof(GeographyModel).Name);
            var list = collection.Aggregate(pipeline).ToList();
            list.ForEach(item =>
            {
                result.Add(JsonConvert.DeserializeObject<CountyVo>(item.GetValue("_id").ToJson()));
            });
            return result.OrderBy(a => a.CountyCode).ToList();
        }
        /// <summary>
        /// 查询镇
        /// </summary>
        /// <returns></returns>
        public List<TownVo> GetTownList(string countyCode)
        {
            var result = new List<TownVo>();
            string matchPipeline = @"{'$match':{'CountyCode':'" + countyCode + "'}}";
            string groupPipeline = @"{'$group':{'_id':{'TownCode':'$TownCode','TownName':'$TownName'}}}";

            IList<IPipelineStageDefinition> stages = new List<IPipelineStageDefinition>();
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(matchPipeline));
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(groupPipeline));
            var pipeline = new PipelineStagePipelineDefinition<BsonDocument, BsonDocument>(stages);

            var collection = database.GetCollection<BsonDocument>(typeof(GeographyModel).Name);
            var list = collection.Aggregate(pipeline).ToList();
            list.ForEach(item =>
            {
                result.Add(JsonConvert.DeserializeObject<TownVo>(item.GetValue("_id").ToJson()));
            });
            return result.OrderBy(a => a.TownCode).ToList();
        }
        /// <summary>
        /// 查询乡
        /// </summary>
        /// <returns></returns>
        public List<VillageVo> GetVillageList(string townCode)
        {
            var result = new List<VillageVo>();
            string matchPipeline = @"{'$match':{'TownCode':'" + townCode + "'}}";
            string groupPipeline = @"{'$group':{'_id':{'VillageCode':'$VillageCode','VillageName':'$VillageName'}}}";
                        
            IList<IPipelineStageDefinition> stages = new List<IPipelineStageDefinition>();
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(matchPipeline));
            stages.Add(new JsonPipelineStageDefinition<BsonDocument, BsonDocument>(groupPipeline));
            var pipeline = new PipelineStagePipelineDefinition<BsonDocument, BsonDocument>(stages);

            var collection = database.GetCollection<BsonDocument>(typeof(GeographyModel).Name);
            var list = collection.Aggregate(pipeline).ToList();
            list.ForEach(item =>
            {
                result.Add(JsonConvert.DeserializeObject<VillageVo>(item.GetValue("_id").ToJson()));
            });
            return result.OrderBy(a => a.VillageCode).ToList();
        }
        /// <summary>
        /// 查询所有数据(指定列)
        /// </summary>
        /// <returns></returns>
        public List<ResultT> List<T, ResultT>()
        {
            var resultType = typeof(ResultT);
            var projectionList = new List<ProjectionDefinition<T>>();
            foreach (var p in resultType.GetProperties())
            {
                projectionList.Add(Builders<T>.Projection.Include(p.Name));
            }
            ProjectionDefinition<T> projectionDefinition = Builders<T>.Projection.Combine(projectionList);
            IMongoCollection<T> collection = database.GetCollection<T>(typeof(T).Name);
            var filter = new BsonDocument();
            return collection.Find(filter).Project<ResultT>(projectionDefinition).ToList().Distinct().ToList();
        }
    }
}
