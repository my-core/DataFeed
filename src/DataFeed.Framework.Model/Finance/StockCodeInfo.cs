using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Framework.Model
{
    /// <summary>
    /// 股票代码
    /// </summary>
    [Table("finance_stocks")]
    public class StockInfo
    {
        /// <summary>
        /// 股票ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 股票代码
        /// </summary>
        public string StockCode { get; set; }
        /// <summary>
        /// 股票名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 市场类型
        /// </summary>
        public int MarketType { get; set; }
        /// <summary>
        /// 市场子类型
        /// </summary>
        public int SubMarketType { get; set; }
        /// <summary>
        /// 上市时间
        /// </summary>
        public DateTime MarktTime { get; set; }
    }
}
