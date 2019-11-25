using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFeed.ManageWeb.Application.Models
{
    /// <summary>
    /// Ajax请求结果
    /// </summary>
    public class AjaxResult
    {
        /// <summary>
        /// 默认true
        /// </summary>
        public bool IsOk { get; set; } = true;
        public string Msg { get; set; } = "操作成功";
        public object Data { get; set; } = null;
    }
}