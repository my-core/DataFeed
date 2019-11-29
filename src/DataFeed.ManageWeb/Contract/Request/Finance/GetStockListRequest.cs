
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataFeed.ManageWeb.Contract;

namespace DataFeed.ManageWeb.Contract.Request
{
    /// <summary>
    /// 查询管理员列表请求
    /// </summary>
    public class GetStockListRequest : PageRequest
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
        /// 市场
        /// </summary>
        public int MatketType { get; set; }
        /// <summary>
        /// 子市场
        /// </summary>
        public int SubMatketType { get; set; }
    }
}