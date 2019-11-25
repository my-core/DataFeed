
using FastNet.Framework.Dapper.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.Framework.Model
{
    /// <summary>
    /// 权限信息
    /// </summary>
    [Table("sys_auth")]
    public class AuthInfo
    {
        public int ID { get; set; }
        /// <summary>
        /// 权限类型(1-菜单 2-页面 3-按钮)
        /// </summary>
        public int AuthType { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string AuthName { get; set; }
        /// <summary>
        /// 权限编码
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int ParentID { get; set; }
        /// Url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// icon样式
        /// </summary>
        public string IconClass { get; set; }
    }
}
