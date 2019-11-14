using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Geography.Model
{
    /// <summary>
    /// 城市信息
    /// </summary>    
    [Table("geo_city")]
    public class CityInfo
    {
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityID { get; set; }
        /// <summary>
        /// 所属省
        /// </summary>
        public string ProvinceCode { get; set; }
        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 城市名
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        public string Spell { get; set; }
        /// <summary>
        /// 首字母
        /// </summary>
        public string FirstLetter { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode { get; set; }

        
    }
}
