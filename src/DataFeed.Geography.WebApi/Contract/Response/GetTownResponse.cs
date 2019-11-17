using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Geography.WebApi.Contract.Response
{
    /// <summary>
    /// 镇信息
    /// </summary>
    public class GetTownResponse
    {        
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
