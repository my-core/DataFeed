
using DataFeed.Framework.Model;
using DataFeed.Framework.Service;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.ManageWeb.Contract.Response;
using FastNet.Framework.Dapper;
using System.Collections.Generic;

namespace DataFeed.ManageWeb.Service
{
    /// <summary>
    /// 业务基础层
    /// </summary>
    public interface IFinanceService : IBaseService
    {
        PagedList<GetStockListResponse> GetStockList(GetStockListRequest request);
    }
}
