using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Framework.Enums
{
    /// <summary>
    /// 股票市场类型
    /// </summary>
    public enum MarketType
    {
        /// <summary>
        /// 上交所
        /// </summary>
        SH = 1,
        /// <summary>
        /// 深交所
        /// </summary>
        SZ = 2
    }

    /// <summary>
    /// 股票市场子类型
    /// </summary>
    public enum SubMarketType
    {
        /// <summary>
        /// A股
        /// </summary>
        A = 1,
        /// <summary>
        /// B股
        /// </summary>
        B = 2,
        /// <summary>
        /// 科创板
        /// </summary>
        STARMarket = 3
    }
}
