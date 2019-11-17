using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Framework.Model
{
    /// <summary>
    /// 乡村信息
    /// </summary>    
    [Table("geo_village")]
    public class VillageInfo
    {
        /// <summary>
        /// 乡村ID
        /// </summary>
        public int VillageID { get; set; }
        /// <summary>
        /// 镇编码
        /// </summary>
        public string TownCode { get; set; }
        /// <summary>
        /// 乡村编码
        /// </summary>
        public string VillageCode { get; set; }
        /// <summary>
        /// 乡村名
        /// </summary>
        public string VillageName { get; set; }
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
