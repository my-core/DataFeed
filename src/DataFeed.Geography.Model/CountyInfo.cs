using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Geography.Model
{
    /// <summary>
    /// 地区信息
    /// </summary>    
    [Table("County")]
    public class CountyInfo
    {
        /// <summary>
        /// 地区编码
        /// </summary>
        public string CountyCode { get; set; }

        /// <summary>
        /// 地区名
        /// </summary>
        public string CountyName { get; set; }

        /// <summary>
        /// 所属城市编码
        /// </summary>
        public int CityCode { get; set; }
    }
}
