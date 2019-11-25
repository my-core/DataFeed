using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFeed.ManageWeb.Application.Models
{
    /// <summary>
    /// 权限类别
    /// </summary>
    public enum AuthType
    {
        /// <summary>
        /// 功能模块
        /// </summary>
        Module = 1,
        /// <summary>
        /// 页面
        /// </summary>
        Page = 2,
        /// <summary>
        /// 动作(事件)
        /// </summary>
        Action = 3
    }
}