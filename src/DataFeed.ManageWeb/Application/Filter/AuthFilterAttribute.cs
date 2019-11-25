 using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataFeed.ManageWeb.Application.Extensions;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataFeed.ManageWeb.Application.Models;
using DataFeed.Framework.Model;

namespace DataFeed.ManageWeb.Application.Filter
{
    /// <summary>
    /// 验证管理员登录状态及权限
    /// </summary>
    public class AuthFilterAttribute: ActionFilterAttribute
    {
        /// <summary>
        /// do something before the action executes
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {           
            //匿名访问
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
                return;

            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
           
            //获取管理员登录信息
            AdminInfo adminInfo = context.HttpContext.Session.Get<AdminInfo>("Yiho_LoginUserInfo");
            //登录信息为空（未登录或登录失效）
            if (adminInfo == null)
            {
                context.HttpContext.Response.Redirect("/Login");
                return;
            }
            //超级管理员、Home模块不验证管理员权限
            if (adminInfo.IsSuper || controller.ToLower() == "home")
            {
                return;
            }
            //获取管理员权限
            List<AuthInfo> LoginUserAuthList = context.HttpContext.Session.Get<List<AuthInfo>>("Yiho_LoginUserAuthInfo");
            //管理员权限为空
            if (LoginUserAuthList == null)
            {
                if (!context.HttpContext.Request.IsAjax())
                {
                    context.HttpContext.Response.Redirect("/Home/NoAuthTip");
                }
                else
                {
                    context.Result = new JsonResult(new AjaxResult { IsOk = false, Msg = "操作权限不足，请联系管理员！" });
                }
                return;

            }
            //验证权限
            var authInfo = LoginUserAuthList.Where(a => a.AuthCode.ToLower() == string.Format("{0}.{1}", controller, action).ToLower());
            if (authInfo == null || authInfo.Count() == 0)
            {
                if (!context.HttpContext.Request.IsAjax())
                {
                    context.HttpContext.Response.Redirect("/Home/NoAuthTip");
                }
                else
                {
                    context.Result = new JsonResult(new AjaxResult { IsOk = false, Msg = "操作权限不足，请联系管理员！" });
                }
                return;
            }
            //var args = context.ActionArguments;
            //var result = context.Result;
            //ActionArguments - lets you manipulate the inputs to the action.

        }
    }
}

