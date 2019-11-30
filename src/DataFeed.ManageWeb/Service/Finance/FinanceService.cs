
using DataFeed.Framework.Enums;
using DataFeed.Framework.Model;
using DataFeed.Framework.Service;
using DataFeed.Framework.Utils;
using DataFeed.ManageWeb.Contract.Base;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.ManageWeb.Contract.Response;
using DataFeed.ManageWeb.Repository;
using FastNet.Framework.Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataFeed.ManageWeb.Service
{
    /// <summary>
    /// 业务基础层
    /// </summary>
    public class FinanceService : BaseService, IFinanceService
    {
        private ILogger<FinanceService> _logger;
        private IFinanceRepository _financeRepository;
        public FinanceService(ILogger<FinanceService> logger, IFinanceRepository financeRepository)
            :base(financeRepository)
        {
            _logger = logger;
            _financeRepository = financeRepository;
        }

        public PagedList<GetStockListResponse> GetStockList(GetStockListRequest request)
        {
            PagedList<StockInfo> stockInfos = GetPageList<StockInfo>(request.PageIndex, request.PageSize, "ID");
            List<GetStockListResponse> list = new List<GetStockListResponse>();
            foreach(var stock in stockInfos)
            {
                list.Add(new GetStockListResponse
                {
                    ID=stock.ID,
                    StockCode=stock.StockCode,
                    StockName=stock.StockName,
                    MarketName= MarketExtension.GetMarket(stock.MarketType),
                    SubMarketName = MarketExtension.GetSubMarket(stock.MarketType)

                });
            }
            return new PagedList<GetStockListResponse>(list, request.PageIndex, request.PageSize, stockInfos.TotalRecordCount);
        }
    }
}
