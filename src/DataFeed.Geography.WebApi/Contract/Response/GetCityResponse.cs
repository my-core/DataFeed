using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Geography.WebApi.Contract.Response
{
    /// <summary>
    /// 城市信息
    /// </summary>    
    public class GetCityResponse
    {    
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
    }
}
