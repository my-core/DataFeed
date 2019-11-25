using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastNet.Framework.Dapper.Mapper;

namespace DataFeed.Framework.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("sys_admin")]
    public class AdminInfo
    {
        public int ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 是否超级管理员(如果是，则不验证权限)
        /// </summary>
        public bool IsSuper { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
