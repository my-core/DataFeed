using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Framework.Model
{
    /// <summary>
    /// 镇信息
    /// </summary>    
    [Table("geo_town")]
    public class TownInfo
    {
        /// <summary>
        /// 镇ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 区编码
        /// </summary>
        public string CountyCode { get; set; }
        /// <summary>
        /// 镇编码
        /// </summary>
        public string TownCode { get; set; }
        /// <summary>
        /// 镇名
        /// </summary>
        public string TownName { get; set; }
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
