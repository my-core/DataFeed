using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Geography.WebApi.Contract.Response
{
    /// <summary>
    /// 区信息
    /// </summary>
    public class GetCountyResponse
    {
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
