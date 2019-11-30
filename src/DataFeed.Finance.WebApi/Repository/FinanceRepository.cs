using Dapper;
using DataFeed.Finance.WebApi.Contract.Request;
using DataFeed.Framework.Model;
using DataFeed.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Finance.WebApi.Repository
{
    /// <summary>
    /// 金融相关数据层接口
    /// </summary>
    public class FinanceRepository : MySqlRepository
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="connString"></param>
        public FinanceRepository(string connString) : base(connString) { }

        /// <summary>
        /// 获取股票信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<StockInfo> GetStockCodeList(GetStockCodeRequest request)
        {
            var sbSql = new StringBuilder(@" select * from finance_stockcode where 1=1");
            var param = new DynamicParameters();
            if (request.MarketType>0)
            {
                sbSql.Append(" and MarketType = ?MarketType");
                param.Add("MarketType", (int)request.MarketType);
            }
            if (request.SubMarketType > 0)
            {
                sbSql.Append(" and SubMarketType = ?SubMarketType");
                param.Add("SubMarketType", (int)request.SubMarketType );
            }
            using (var conn = OpenConnection())
            {
                return conn.Query<StockInfo>(sbSql.ToString(), param).AsList();
            }
        }
    }
}
