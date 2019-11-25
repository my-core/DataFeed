using DataFeed.Framework.Model;
using DataFeed.ManageWeb.Application.Extensions;
using DataFeed.ManageWeb.Application.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.ManageWeb.Application.Middleware
{
    public class AuthMiddleware
    {
        /// <summary>
        /// 管道代理对象
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// 权限中间件构造
        /// </summary>
        /// <param name="next">管道代理对象</param>
        /// <param name="permissionResitory">权限仓储对象</param>
        /// <param name="option">权限中间件配置选项</param>
        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// 调用管道
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <returns></returns>
        public Task Invoke(HttpContext context)
        {
            //请求Url
            var requestUrl = context.Request.Path.Value.ToLower();

            //是否经过验证
            var isAuthenticated = context.User.Identity.IsAuthenticated;
            if (!isAuthenticated || requestUrl.Contains("/home") || requestUrl.Contains("/login") || requestUrl == "/")
            {
                return _next(context);
            }
            //超级管理员不验证权限
            AdminInfo adminInfo= JsonConvert.DeserializeObject<AdminInfo>(context.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.UserData).Value);
            if(adminInfo!=null && adminInfo.IsSuper)
            {
                return _next(context);
            }
            //非超级管理员验证权限
            List<AuthInfo> authList = JsonConvert.DeserializeObject<List<AuthInfo>>(context.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Authentication).Value);
            if (authList.Where(w => !string.IsNullOrEmpty(w.Url) && requestUrl.Contains(w.Url.ToLower())).Count() > 0)
            {
                return _next(context);
            }
            else
            {
                if (context.Request.IsAjax())
                {
                    AjaxResult result = new AjaxResult { IsOk = false, Msg = "操作权限不足，请联系管理员！" };
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                }
                else
                {
                    //无权限跳转到拒绝页面
                    context.Response.Redirect("/Home/NoAuthTip");
                }
            }
            return _next(context);
        }
    }
    /// <summary>
    /// 扩展权限中间件
    /// </summary>
    public static class AuthMiddlewareExtensions
    {
        /// <summary>
        /// 引入权限验证中间件
        /// </summary>
        /// <param name="builder">扩展类型</param>
        /// <param name="option">权限中间件配置选项</param>
        /// <returns></returns>
        public static IApplicationBuilder UseAuth(
              this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }

    /// <summary>
    /// 权限中间件选项
    /// </summary>
    public class AuthMiddlewareOption
    {
        /// <summary>
        /// 登录action
        /// </summary>
        public string LoginAction
        { get; set; }
        /// <summary>
        /// 无权限导航action
        /// </summary>
        public string NoPermissionAction
        { get; set; }

        /// <summary>
        /// 管理员权限集合
        /// </summary>
        public List<AuthInfo> UserAuthList
        { get; set; } = new List<AuthInfo>();
    }
}
