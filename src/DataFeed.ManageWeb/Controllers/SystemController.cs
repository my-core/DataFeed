using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using DataFeed.ManageWeb.Service;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.ManageWeb.Contract.Response;
using DataFeed.Framework.Model;
using DataFeed.ManageWeb.Application.Models;
using Microsoft.AspNetCore.Authorization;
using FastNet.Framework.Dapper;
using DataFeed.Framework.Utils;

namespace FDataFeed.ManageWeb.Controllers
{
    /// <summary>
    /// 管理员模块
    /// </summary>
    public class SystemController : BaseController
    {
        public ISystemService _systemService { get; set; }
        public SystemController(ISystemService systemService)
        {
            _systemService = systemService;
        }

        #region 管理员管理
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ActionResult AdminList(GetAdminListRequest request)
        {
            PagedList<GetAdminListResponse> list = _systemService.GetAdminList(request);
            return View(list);
        }
        /// <summary>
        /// 管理员添加
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminAdd(int id)
        {
            ViewData["Roles"] = new SelectList(_systemService.GetList<RoleInfo>(), "ID", "RoleName");
            AdminInfo info = _systemService.GetModel<AdminInfo>(new { ID = id });
            return View(info ?? new AdminInfo());
        }
        /// <summary>
        /// 管理员添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdminAdd(AdminInfo info, IFormCollection form)
        {
            info.IsSuper = form["IsSuper"].ToString().ToLower() == "on" ? true : false;
            if (info.ID == 0)
            {
                info.Password = RSADEncrypt.Encrypt(info.Password);
                info.CreateBy = LoginAdminInfo.ID;
                info.CreateTime = DateTime.Now;

                if (_systemService.Insert(info) > 0)
                {
                    Result.IsOk = true;
                    Result.Msg = "添加成功";
                }
                else
                {
                    Result.IsOk = false;
                    Result.Msg = "添加失败";
                }
            }
            else
            {
                if (_systemService.Update(info))
                {
                    Result.IsOk = true;
                    Result.Msg = "更新成功";
                }
                else
                {
                    Result.IsOk = false;
                    Result.Msg = "更新失败";
                }
            }
            return Json(Result);
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult AdminDelete(int id)
        {
            if (_systemService.Delete<AdminInfo>(new { ID = id }))
            {
                Result.IsOk = true;
                Result.Msg = "删除成功";
            }
            else
            {
                Result.IsOk = false;
                Result.Msg = "删除失败";
            }
            return Json(Result);
        }
        /// <summary>
        /// 管理员修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminPwd(string id)
        {
            AdminInfo info = _systemService.GetModel<AdminInfo>(new { ID = id });
            return View(info ?? new AdminInfo());
        }
        /// <summary>
        /// 管理员修改密码
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdminPwd(AdminInfo info)
        {
            AdminInfo user = _systemService.GetModel<AdminInfo>(new { ID = info.ID });
            user.Password = RSADEncrypt.Encrypt(info.Password);
            if (_systemService.Update(user))
            {
                Result.IsOk = true;
                Result.Msg = "修改成功";
            }
            else
            {
                Result.IsOk = false;
                Result.Msg = "修改失败";
            }
            return Json(Result);
        }
        #endregion

        #region 角色管理
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ActionResult RoleList(GetRoleListRequest request)
        {
            PagedList<GetRoleListResponse> list = _systemService.GetRoleList(request);
            return View(list);
        }
        /// <summary>
        /// 角色添加
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleAdd(string id)
        {
            RoleInfo info = _systemService.GetModel<RoleInfo>(new { ID = id });
            //获取所有权限
            List<AuthInfo> allPermission = _systemService.GetList<AuthInfo>();
            //获取角色对应的权限
            var rolePermission = _systemService.GetList<RoleAuth>(new { RoleID = id });
            var ztree = from p in allPermission
                        select new ZTreeData
                        {
                            id = p.ID,
                            pId = p.ParentID,
                            name = p.AuthName,
                            value = p.ID,
                            Checked = rolePermission.Exists(a => a.AuthID == p.ID)
                        };
            //序列化为ztree所需要的json串
            ViewBag.PermissionList = JsonConvert.SerializeObject(ztree);
            //构造隐藏域的值
            ViewBag.PermissionIDs = GetRolePermissionIDs(rolePermission);
            return View(info ?? new RoleInfo());
        }
        /// <summary>
        /// 角色添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RoleAdd(RoleInfo info, IFormCollection form)
        {
            if (info.ID == 0)
            {
                info.CreateBy = LoginAdminInfo.ID;
                info.CreateTime = DateTime.Now;
                var roleID = Convert.ToInt32(_systemService.Insert(info));
                if (roleID > 0)
                {
                    string permissionIDs = form["PermissionIDs"];
                    _systemService.Insert(GetRolePermissionList(roleID, permissionIDs));
                    Result.IsOk = true;
                    Result.Msg = "添加成功";
                }
                else
                {
                    Result.IsOk = false;
                    Result.Msg = "添加失败";
                }
            }
            else
            {
                if (_systemService.Update(info))
                {
                    string permissionIDs = form["PermissionIDs"];
                    _systemService.Delete<RoleAuth>(new { info.ID });
                    _systemService.Insert(GetRolePermissionList(info.ID, permissionIDs));
                    Result.IsOk = true;
                    Result.Msg = "更新成功";
                }
                else
                {
                    Result.IsOk = false;
                    Result.Msg = "更新失败";
                }
            }
            return Json(Result);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult RoleDelete(int id)
        {
            if (_systemService.Delete<RoleInfo>(new { ID = id }))
            {
                Result.IsOk = true;
                Result.Msg = "删除成功";
            }
            else
            {
                Result.IsOk = false;
                Result.Msg = "删除失败";
            }
            return Json(Result);
        }
        /// <summary>
        /// 获取角色权限List
        /// </summary>
        /// <returns></returns>
        public List<RoleAuth> GetRolePermissionList(int roleID, string permissionIDs)
        {
            List<RoleAuth> list = new List<RoleAuth>();
            foreach (string id in permissionIDs.Split(",".ToArray()))
            {
                if (string.IsNullOrEmpty(id))
                    continue;
                list.Add(new RoleAuth { RoleID = roleID, AuthID = int.Parse(id) });
            }
            return list;
        }
        /// <summary>
        /// 构造角色权限ID集
        /// </summary>
        /// <returns></returns>
        public string GetRolePermissionIDs(List<RoleAuth> list)
        {
            string permissinIDs = "";
            foreach (RoleAuth info in list)
            {
                if (permissinIDs != "")
                    permissinIDs += ",";
                permissinIDs += info.AuthID;
            }
            return permissinIDs;
        }

        #endregion

        #region 权限管理
        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ActionResult AuthList()
        {
            return View(GetAuthForSelect());
        }
        /// <summary>
        /// 权限添加
        /// </summary>
        /// <returns></returns>
        public ActionResult AuthAdd(string id)
        {
            AuthInfo info = _systemService.GetModel<AuthInfo>(new { ID = id }) ?? new AuthInfo();
            if (info.AuthType == 0)
                info.AuthType = (int)AuthType.Module;
            ViewData["AuthTypeList"] = GetAuthTypeForSelect();
            ViewData["AuthList"] = new SelectList(from p in GetAuthForSelect() where p.AuthType != (int)AuthType.Action select p, "ID", "AuthName");
            return View(info);
        }
        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AuthAdd(AuthInfo info)
        {
            if (info.ID == 0)
            {
                AuthInfo hasInfo = _systemService.GetModel<AuthInfo>(new { info.AuthCode });
                if (hasInfo != null && hasInfo.ID > 0)
                {
                    Result.IsOk = false;
                    Result.Msg = "权限编码已存在";
                }
                else
                {
                    if (_systemService.Insert(info) > 0)
                    {
                        Result.IsOk = true;
                        Result.Msg = "添加成功";
                    }
                    else
                    {
                        Result.IsOk = false;
                        Result.Msg = "添加失败";
                    }
                }
            }
            else
            {
                if (_systemService.Update(info))
                {
                    Result.IsOk = true;
                    Result.Msg = "更新成功";
                }
                else
                {
                    Result.IsOk = false;
                    Result.Msg = "更新失败";
                }
            }
            return Json(Result);
        }
        /// <summary>
        /// 权限角色
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult AuthDelete(string id)
        {
            if (_systemService.Delete<AuthInfo>(new { ID = id }))
            {
                Result.IsOk = true;
                Result.Msg = "删除成功";
            }
            else
            {
                Result.IsOk = false;
                Result.Msg = "删除失败";
            }
            return Json(Result);
        }
        #endregion


        /// <summary>
        /// 构造权限下拉框数据
        /// </summary>
        /// <returns></returns>
        protected List<AuthInfo> GetAuthForSelect()
        {
            List<AuthInfo> allAuth = _systemService.GetList<AuthInfo>();
            List<AuthInfo> authTemp = new List<AuthInfo>();

            var listP1 = from p in allAuth
                         where p.AuthType == 1
                         orderby p.Sort
                         select p;
            foreach (var item1 in listP1)
            {
                authTemp.Add(item1);
                var listP2 = from p in allAuth
                             where p.AuthType == 2 && p.ParentID == item1.ID
                             orderby p.Sort
                             select p;
                foreach (var item2 in listP2)
                {
                    item2.AuthName = "|----" + item2.AuthName;
                    authTemp.Add(item2);
                    var listP3 = from p in allAuth
                                 where p.AuthType == 3 && p.ParentID == item2.ID
                                 orderby p.Sort
                                 select p;
                    foreach (var item3 in listP3)
                    {
                        item3.AuthName = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|----" + item3.AuthName;
                        authTemp.Add(item3);
                    }
                }
            }
            return authTemp;
        }

        /// <summary>
        /// 构造权限类别下拉框数据
        /// </summary>
        /// <returns></returns>
        protected SelectList GetAuthTypeForSelect()
        {
            List<TextValue> list = new List<TextValue>
            {
                new TextValue { Value = (int)AuthType.Module, Text = "模块" },
                new TextValue { Value =  (int)AuthType.Page, Text = "页面" },
                new TextValue { Value =  (int)AuthType.Action, Text = "操作" }
            };
            return new SelectList(list, "Value", "Text");
        }

    }
}