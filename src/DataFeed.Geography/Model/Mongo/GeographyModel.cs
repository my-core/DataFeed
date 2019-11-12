using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.Model.Mongo
{
    public class GeographyModel: BaseModel
    {
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }

        public string CityCode { get; set; }
        public string CityName { get; set; }

        public string CountyCode { get; set; }
        public string CountyName { get; set; }

        public string TownCode { get; set; }
        public string TownName { get; set; }

        public string VillageCode { get; set; }
        public string VillageName { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

    }
}
