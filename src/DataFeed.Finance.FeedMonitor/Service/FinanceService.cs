
using DataFeed.Finance.FeedMonitor.Repository;
using DataFeed.Framework.Model;
using DataFeed.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFeed.Finance.WebApi.Service
{
    /// <summary>
    /// 金融相关业务
    /// </summary>
    public class FinanceService : BaseService, IBaseService
    {
        private FinanceRepository _financeRepository;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="financeRepository"></param>
        /// <param name="mapper"></param>
        public FinanceService(FinanceRepository financeRepository)
            : base(financeRepository)
        {
            _financeRepository = financeRepository;
        }
        /// <summary>
        /// 股票代码
        /// </summary>
        /// <returns></returns>
        public void InsertStockCompany()
        {
        }          
    }
}
