
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using DataFeed.Framework.Repository;
using DataFeed.ManageWeb.Contract.Response;
using FastNet.Framework.Dapper;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.Framework.Model;

namespace DataFeed.ManageWeb.Repository
{
    public class SystemRepository : MySqlRepository, ISystemRepository
    {
        public SystemRepository(string connString) : base(connString) { }

        #region 管理员管理
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PagedList<GetAdminListResponse> GetAdminList(GetAdminListRequest request)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"select a.*,b.RoleName,c.RealName as CreateAdmin from sys_admin a
                            left join sys_role b on b.ID=a.RoleID
                            left join sys_admin c on c.ID=a.CreateBy
                            where 1=1 ");
            var param = new DynamicParameters();


            if (!string.IsNullOrEmpty(request.AdminName))
            {
                sbSql.Append(" and a.AdminName like ?AdminName");
                param.Add("AdminName", "%" + request.AdminName + "%");
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                sbSql.Append(" and a.RealName like ?RealName");
                param.Add("RealName", "%" + request.Name + "%");
            }
            request.OrderBy = "a.CreateTime desc";
            return GetPagedList<GetAdminListResponse>(sbSql.ToString(), param, request.PageIndex, request.PageSize, request.OrderBy);
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PagedList<GetRoleListResponse> GetRoleList(GetRoleListRequest request)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"select a.*,b.RealName as CreateAdmin from sys_role a
                            left join sys_admin b on b.ID=a.CreateBy");
            var param = new DynamicParameters();

            if (!string.IsNullOrEmpty(request.RoleName))
            {
                sbSql.Append(" and RoleName like ?RoleName");
                param.Add("RoleName", "%" + request.RoleName + "%");
            }
            request.OrderBy = "a.CreateTime desc";
            return GetPagedList<GetRoleListResponse>(sbSql.ToString(), param, request.PageIndex, request.PageSize, request.OrderBy);
        }
        /// <summary>
        /// 获取管理员权限
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<AuthInfo> GetAdminAuth(int adminID)
        {
            StringBuilder sbSql = new StringBuilder();
            var param = new DynamicParameters();
            sbSql.Append(@"select c.* from sys_role_auth a
                            inner join sys_admin b on b.RoleID=a.RoleID
                            inner join sys_auth c on c.ID=a.AuthID
                            where b.ID=@AdminID");
            param.Add("AdminID", adminID);
            return GetList<AuthInfo>(sbSql.ToString(), param);
        }
        #endregion


    }
}
