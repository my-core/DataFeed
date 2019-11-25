using DataFeed.Framework.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.ManageWeb.Contract.Response
{
    public class AdminLoginResponse
    {
        /// <summary>
        ///  登录结果
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 登录信息
        /// </summary>
        public AdminInfo LoginAdminInfo { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public List<AuthInfo> AuthList { get; set; }
    }
}
