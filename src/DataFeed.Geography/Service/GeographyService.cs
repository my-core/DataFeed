using DataFeed.Geography.Model.Mongo;
using DataFeed.Geography.Repository.Mongodb;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.Service
{
    public class GeographyService : IGeographyService
    {
        private ILogger<GeographyService> _logger;
        private IGeographyMongoRepository _geographyRepository;
        public GeographyService(ILogger<GeographyService> logger, IGeographyMongoRepository geographyRepository)
        {
            _logger = logger;
            _geographyRepository = geographyRepository;
        }

        public void InsertGeography(List<GeographyModel> list)
        {
            _geographyRepository.Insert(list);
        }
    }
}
