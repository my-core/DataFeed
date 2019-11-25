/*********************************************************************
*Copyright (c) 2018 深圳房讯通信息技术有限公司 All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：深圳房讯通信息技术有限公司
*命名空间：DataFeed.ManageWeb.Contract.Response.User
*文件名：  UserLoginRequest
*版本号：  V1.0.0.0
*创建人：  Mibin
*创建时间：2018-6-15 15:44:30
*描述：
*
*--------------多次修改可添加多块注释---------------
*修改时间：2018-6-15 15:44:30
*修改人： Mibin
*描述：first create
*
**********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.ManageWeb.Contract.Request
{
    /// <summary>
    /// 管理员登录
    /// </summary>
    public class AdminLoginRequest
    {
        public string AdminName { get; set; }
        public string Password { get; set; }
    }
}
