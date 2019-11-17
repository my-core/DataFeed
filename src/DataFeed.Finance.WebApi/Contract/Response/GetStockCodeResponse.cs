using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Finance.WebApi.Contract.Response
{
    /// <summary>
    /// 乡村信息
    /// </summary>
    public class GetStockCodeResponse
    {
        /// <summary>
        /// 股票代码
        /// </summary>
        public string StockCode { get; set; }
        /// <summary>
        /// 股票名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 上市时间
        /// </summary>
        public DateTime MarktTime { get; set; }


    }
}
