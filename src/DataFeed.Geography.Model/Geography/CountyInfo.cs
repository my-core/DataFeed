using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Framework.Model
{
    /// <summary>
    /// 区信息
    /// </summary>    
    [Table("geo_county")]
    public class CountyInfo
    {
        /// <summary>
        /// 区ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 所属城市编码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 区编码
        /// </summary>
        public string CountyCode { get; set; }
        /// <summary>
        /// 区名
        /// </summary>
        public string CountyName { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        public string Spell { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        public string FirstLetter { get; set; }


    }
}
