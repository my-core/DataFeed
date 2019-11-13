using System;
using System.Collections.Generic;
using System.Text;
using TCM.Rich.DbBuilder.DapperExtension;
using Dapper;

namespace DataFeed.Geography.DataAccess
{
    public class GeographyRepository : SqlServerRepository, IGeographyRepository
    {
        public GeographyRepository(string connString)
            : base(connString) { }


        
    }
}
