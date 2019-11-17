using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataFeed.Finance.WebApi.Contract.Request;
using DataFeed.Finance.WebApi.Contract.Response;
using DataFeed.Finance.WebApi.Service;
using DataFeed.Framework.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataFeed.Finance.WebApi.Controllers
{
    /// <summary>
    /// 股票信息接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
       
        private readonly ILogger<StockController> _logger;
        private FinanceService _financeService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="financeService"></param>
        public StockController(ILogger<StockController> logger, FinanceService financeService)
        {
            _logger = logger;
            _financeService = financeService;
        }

        /// <summary>
        /// 获取股票代码信息
        /// </summary>
        /// <param name="marketType">1-上交所 2-深交所</param>
        /// <param name="subMarketType">1-A股 2-B股 3-科创板</param>
        /// <returns></returns>
        [HttpGet()]
        public ApiResponse<List<GetStockCodeResponse>> GetStockCodeList(int marketType, int subMarketType)
        {
            return _financeService.GetStockCodeList(new GetStockCodeRequest
            {
                MarketType = (MarketType)marketType,
                SubMarketType = (SubMarketType)subMarketType
            });
        }
    }
}
