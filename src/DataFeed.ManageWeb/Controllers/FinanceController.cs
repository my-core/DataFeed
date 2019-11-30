using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using DataFeed.ManageWeb.Service;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.ManageWeb.Contract.Response;
using DataFeed.Framework.Model;
using DataFeed.ManageWeb.Application.Models;
using Microsoft.AspNetCore.Authorization;
using FastNet.Framework.Dapper;
using DataFeed.Framework.Utils;

namespace FDataFeed.ManageWeb.Controllers
{
    /// <summary>
    /// 财经模块
    /// </summary>
    public class FinanceController : BaseController
    {
        public IFinanceService _financeService { get; set; }
        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        #region 股票管理
        /// <summary>
        /// 股票列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ActionResult StockList(GetStockListRequest request)
        {
            PagedList<GetStockListResponse> list = _financeService.GetStockList(request);
            return View(list);
        }
        /// <summary>
        /// 股票添加
        /// </summary>
        /// <returns></returns>
        public ActionResult StockAdd(int id)
        {
            StockInfo info = _financeService.GetModel<StockInfo>(new { ID = id });
            return View(info ?? new StockInfo());
        }
        /// <summary>
        /// 股票添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StockAdd(StockInfo info)
        {
            if (info.ID > 0)
            {
                if (_financeService.Insert(info) > 0)
                {
                    Result.IsOk = true;
                    Result.Msg = "添加成功";
                }
                else
                {
                    Result.IsOk = false;
                    Result.Msg = "添加失败";
                }
            }
            else
            {
                if (_financeService.Update(info))
                {
                    Result.IsOk = true;
                    Result.Msg = "更新成功";
                }
                else
                {
                    Result.IsOk = false;
                    Result.Msg = "更新失败";
                }
            }
            return Json(Result);
        }
        /// <summary>
        /// 删除股票
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult StockDelete(int id)
        {
            if (_financeService.Delete<StockInfo>(new { ID = id }))
            {
                Result.IsOk = true;
                Result.Msg = "删除成功";
            }
            else
            {
                Result.IsOk = false;
                Result.Msg = "删除失败";
            }
            return Json(Result);
        }       
        #endregion

       
    }
}