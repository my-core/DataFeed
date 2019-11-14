using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.FeedMonitor
{
    public class GeographyRepository : MySqlRepository, IGeographyRepository
    {
        public GeographyRepository(string connString)
            : base(connString)
        {

        }

    }
}
