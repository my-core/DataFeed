
using DataFeed.Framework.Model;
using DataFeed.Framework.Service;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.ManageWeb.Contract.Response;
using FastNet.Framework.Dapper;
using System.Collections.Generic;

namespace DataFeed.ManageWeb.Service
{
    /// <summary>
    /// 业务基础层
    /// </summary>
    public interface ISystemService : IBaseService
    {
        #region 管理员管理
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        AdminLoginResponse AdminLogin(AdminLoginRequest request);
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        PagedList<GetAdminListResponse> GetAdminList(GetAdminListRequest request);
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        PagedList<GetRoleListResponse> GetRoleList(GetRoleListRequest request);
        /// <summary>
        /// 获取管理员的权限
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<AuthInfo> GetAdminAuth(int adminID);
        #endregion
    }
}
