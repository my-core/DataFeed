
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataFeed.ManageWeb.Contract;

namespace DataFeed.ManageWeb.Contract.Request
{
    /// <summary>
    /// 查询管理员列表请求
    /// </summary>
    public class GetAdminListRequest : PageRequest
    {
        /// <summary>
        /// 管理员名
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string Name { get; set; }
    }
}