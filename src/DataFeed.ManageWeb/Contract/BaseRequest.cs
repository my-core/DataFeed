using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFeed.ManageWeb.Contract
{
    /// <summary>
    /// 搜索基类
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; } = 8;

        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy { get; set; }
    }
}