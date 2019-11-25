
using DataFeed.Framework.Model;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.ManageWeb.Contract.Response;
using FastNet.Framework.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.ManageWeb.Repository
{
    public interface ISystemRepository : IBaseRepository
    {
        #region 管理员管理
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PagedList<GetAdminListResponse> GetAdminList(GetAdminListRequest request);
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PagedList<GetRoleListResponse> GetRoleList(GetRoleListRequest request);
        /// <summary>
        /// 获取管理员权限
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<AuthInfo> GetAdminAuth(int adminID);
        #endregion

    }
}
