using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Framework.Model
{
    /// <summary>
    /// 省信息
    /// </summary>    
    [Table("geo_province")]
    public class ProvinceInfo
    {
        /// <summary>
        /// 省ID
        /// </summary>
        public int ProvinceID { get; set; }
        /// <summary>
        /// 省编码
        /// </summary>
        public string ProvinceCode { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ShorName { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        public string Spell { get; set; }
        /// <summary>
        /// 首字母
        /// </summary>
        public string FirstLetter { get; set; }
    }
}
