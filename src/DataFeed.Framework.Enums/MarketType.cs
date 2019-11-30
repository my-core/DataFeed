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

    public class MarketExtension
    {
        /// <summary>
        /// 获取市场名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetMarket(int type)
        {
            MarketType marketType = (MarketType)type;
            switch (marketType)
            {
                case MarketType.SH:
                    return "上交所";
                case MarketType.SZ:
                    return "深交所";
                default:
                    return "";
            }
        }
        /// <summary>
        /// 获取子市场名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetSubMarket(int type)
        {
            SubMarketType marketType = (SubMarketType)type;
            switch (marketType)
            {
                case SubMarketType.A:
                    return "A股";
                case SubMarketType.B:
                    return "B股";
                case SubMarketType.STARMarket:
                    return "科创板";
                default:
                    return "";
            }
        }
    }
}
