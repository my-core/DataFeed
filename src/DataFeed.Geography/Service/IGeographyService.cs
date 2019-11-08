using DataFeed.Geography.Model.Mongo;
using DataFeed.Geography.Repository.Mongodb;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.Service
{
    public interface IGeographyService
    {
        void InsertGeography(List<GeographyModel> list);
    }
}
