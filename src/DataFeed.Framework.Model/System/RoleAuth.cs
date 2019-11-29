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
    [Table("sys_role_auth")]
    public class RoleAuth
    {
        public int ID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int AuthID { get; set; }
    }
}
