using DataFeed.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFeed.Finance.WebApi.Contract.Request
{
    public class GetStockCodeRequest
    {
        /// <summary>
        /// 股票市场类型
        /// </summary>
        public MarketType MarketType { get; set; }
        /// <summary>
        /// 股票市场子类型
        /// </summary>
        public SubMarketType SubMarketType { get; set; }
    }
}
