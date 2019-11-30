using Dapper;
using DataFeed.Framework.Model;
using DataFeed.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Finance.FeedMonitor.Repository
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

    }
}
