using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Geography.WebApi.Contract.Response
{
    /// <summary>
    /// 乡村信息
    /// </summary>
    public class GetVillageResponse
    {
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
