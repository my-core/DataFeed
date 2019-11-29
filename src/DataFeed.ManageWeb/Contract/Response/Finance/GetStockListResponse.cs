using DataFeed.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.ManageWeb.Contract.Response
{
    /// <summary>
    /// 股票列表
    /// </summary>
    public class GetStockListResponse : StockInfo
    {
        /// <summary>
        /// 市场
        /// </summary>
        public string MarketName { get; set; }
        /// <summary>
        /// 子市场
        /// </summary>
        public string SubMarketName { get; set; }
    }
}
