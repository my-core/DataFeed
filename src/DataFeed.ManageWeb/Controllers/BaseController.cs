using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataFeed.ManageWeb.Application.Models;
using DataFeed.Framework.Model;
using Newtonsoft.Json;
using System.Security.Claims;

namespace FDataFeed.ManageWeb.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 日志
        /// </summary>
        public ILogger Logger { get; set; }
        /// <summary>
        /// Ajax请求结果
        /// </summary>
        public AjaxResult Result { get; set; }

        /// <summary>
        ///  登录信息
        /// </summary>
        public AdminInfo LoginAdminInfo
        {
            get
            {
                return JsonConvert.DeserializeObject<AdminInfo>(
                    User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.UserData).Value);
            }
           
        }
        /// <summary>
        /// 权限
        /// </summary>
        public List<AuthInfo> LoginAdminAuthList
        {
            get
            {
                return JsonConvert.DeserializeObject<List<AuthInfo>>(
                    User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Authentication).Value);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseController()
        {
            Result = new AjaxResult();
        }
    }
}