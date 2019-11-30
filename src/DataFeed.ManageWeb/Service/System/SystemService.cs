
using DataFeed.Framework.Model;
using DataFeed.Framework.Service;
using DataFeed.Framework.Utils;
using DataFeed.ManageWeb.Contract.Base;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.ManageWeb.Contract.Response;
using DataFeed.ManageWeb.Repository;
using FastNet.Framework.Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataFeed.ManageWeb.Service
{
    /// <summary>
    /// 业务基础层
    /// </summary>
    public class SystemService : BaseService, ISystemService
    {
        private ILogger<SystemService> _logger;
        private ISystemRepository _systemRepository;
        public SystemService(ILogger<SystemService> logger, ISystemRepository systemRepository)
            :base(systemRepository)
        {
            _logger = logger;
            _systemRepository = systemRepository;
        }
        #region 管理员管理

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public AdminLoginResponse AdminLogin(AdminLoginRequest request)
        {
            AdminLoginResponse response = new AdminLoginResponse();
            AdminInfo info = GetModel<AdminInfo>(new { request.AdminName });
            if (info == null)
            {
                response.Result = RT.Admin_NotExist_UserName;
                return response;
            }
            if (request.Password != RSADEncrypt.Decrypt(info.Password))
            {
                response.Result = RT.Admin_Error_Password;
                return response;
            }
            //权限
            if (info.IsSuper)
            {
                response.AuthList = GetList<AuthInfo>();
            }
            else
            {
                response.AuthList = GetAdminAuth(info.ID);
            }
            //登录成功
            response.Result = RT.Success;
            response.AdminInfo = info;
            return response;
        }
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public PagedList<GetAdminListResponse> GetAdminList(GetAdminListRequest request)
        {
            return _systemRepository.GetAdminList(request);
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public PagedList<GetRoleListResponse> GetRoleList(GetRoleListRequest request)
        {
            return _systemRepository.GetRoleList(request);
        }
        /// <summary>
        /// 获取管理员的权限
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<AuthInfo> GetAdminAuth(int adminID)
        {
            return _systemRepository.GetAdminAuth(adminID);
        }
        #endregion

    }
}
