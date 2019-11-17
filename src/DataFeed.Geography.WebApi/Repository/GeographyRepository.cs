using DataFeed.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.WebApi.Repository
{
    public class GeographyRepository : MySqlRepository
    {
        public GeographyRepository(string connString)
            : base(connString)
        {

        }

    }
}
