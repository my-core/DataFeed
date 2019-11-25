using DataFeed.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.ManageWeb.Contract.Response
{
    /// <summary>
    /// 管理员列表
    /// </summary>
    public class GetAdminListResponse : AdminInfo
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateAdmin { get; set; }
    }
}
