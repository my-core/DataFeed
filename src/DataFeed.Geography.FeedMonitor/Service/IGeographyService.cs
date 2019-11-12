using DataFeed.Geography.FeedMonitor.Model.Mongo;
using DataFeed.Geography.FeedMonitor.Repository.Mongodb;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.FeedMonitor.Service
{
    public interface IGeographyService
    {
        void InsertGeography(List<GeographyModel> list);
    }
}
