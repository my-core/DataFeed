 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DataFeed.ManageWeb.Application.Models;
using DataFeed.ManageWeb.Contract.Base;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.ManageWeb.Contract.Response;
using DataFeed.ManageWeb.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FDataFeed.ManageWeb.Controllers
{
    [Route("Login")]
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        public ISystemService _systemService { get; set; }
        public LoginController(ISystemService systemService)
        {
            _systemService = systemService;
        }

        public IActionResult Index(string t)
        {
            HttpContext.SignOutAsync();
            return View();
        }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Index")]
        public AjaxResult Index(AdminLoginRequest request)
        {
            AdminLoginResponse loginResponse = _systemService.UserLogin(request);
            if (loginResponse.Result == RT.Success)
            {
                Result.IsOk = true;
                Result.Msg = "登录成功！";

                var claimIdentity = new ClaimsIdentity("Cookie");
                claimIdentity.AddClaim(new Claim(ClaimTypes.Authentication, JsonConvert.SerializeObject(loginResponse.AuthList)));
                claimIdentity.AddClaim(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(loginResponse.LoginAdminInfo)));

                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                // 在上面注册AddAuthentication时，指定了默认的Scheme，在这里便可以不再指定Scheme。
                HttpContext.SignInAsync(claimsPrincipal);
            }
            else if (loginResponse.Result == RT.User_NotExist_UserName)
            {
                Result.IsOk = false;
                Result.Msg = "管理员名不存在！";
            }
            else if (loginResponse.Result == RT.User_Error_Password)
            {
                Result.IsOk = false;
                Result.Msg = "密码不正确！";
            }
            return Result;
        }
    }
}