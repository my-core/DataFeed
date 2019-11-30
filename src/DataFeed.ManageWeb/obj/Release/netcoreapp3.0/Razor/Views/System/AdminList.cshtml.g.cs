#pragma checksum "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1e5b7855412335d4808415fb580b136c91dc5ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_System_AdminList), @"mvc.1.0.view", @"/Views/System/AdminList.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using FDataFeed.ManageWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using DataFeed.Framework.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using DataFeed.ManageWeb.Application.Pager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using DataFeed.ManageWeb.Contract.Response;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using DataFeed.ManageWeb.Contract.Base;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using FastNet.Framework.Dapper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1e5b7855412335d4808415fb580b136c91dc5ab", @"/Views/System/AdminList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b91a9f9eb8ea4f4704b373dad83ac5468f86b8c", @"/Views/_ViewImports.cshtml")]
    public class Views_System_AdminList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList<GetAdminListResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
  
    ViewBag.Title = "管理员列表";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n");
#nullable restore
#line 7 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
     using (Html.BeginForm("AdminList", "System", FormMethod.Get, new { @class = "layui-form search-form layui-elem-quote", @id = "searchForm" }))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table>
            <tr>
                <th>管理员名：</th>
                <td>
                    <input id=""AdminName"" name=""AdminName"" class=""layui-input"" type=""text"">
                </td>
                <th>姓名：</th>
                <td>
                    <input id=""Name"" name=""Name"" class=""layui-input"" type=""text"">
                </td>
");
            WriteLiteral("                <td>\r\n                    <input type=\"submit\" class=\"layui-btn layui-btn-sm\" value=\"查 询\" />\r\n                </td>\r\n            </tr>\r\n        </table>\r\n");
#nullable restore
#line 35 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div style=""padding:0px 10px;"">
        <a class=""layui-btn layui-btn-sm layui-btn-normal"" href=""javascript:void(0);"" onclick=""AddOrEdit()"">
            <i class=""layui-icon layui-icon-tianjia2""></i>添加管理员
        </a>
    </div>
    <table class=""layui-table"" id=""list"">
        <thead>
            <tr>
                <th style=""text-align:center;"">#</th>
                <th>管理员ID</th>
                <th>管理员名</th>
                <th>姓名</th>
                <th>所属角色</th>
                <th>创建人</th>
                <th>创建时间</th>
                <th>操作</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 55 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
               int index = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td style=\"width:20px; text-align:center;\">");
#nullable restore
#line 59 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
                                                           Write(index++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 60 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
                   Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 61 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
                   Write(item.AdminName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 62 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
                   Write(item.RealName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 63 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
                    Write(item.IsSuper ? "超级管理员" : item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 64 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
                   Write(item.CreateAdmin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 65 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
                   Write(item.CreateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a class=\"layui-btn layui-btn-normal layui-btn-xs\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2601, "\"", 2632, 3);
            WriteAttributeValue("", 2611, "AddOrEdit(\'", 2611, 11, true);
#nullable restore
#line 67 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
WriteAttributeValue("", 2622, item.ID, 2622, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2630, "\')", 2630, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"layui-icon layui-icon-bianji\"></i>编辑</a>\r\n                        <a class=\"layui-btn layui-btn-danger layui-btn-xs\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2760, "\"", 2820, 3);
            WriteAttributeValue("", 2770, "javascript:Delete(\'/System/AdminDelete/", 2770, 39, true);
#nullable restore
#line 68 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
WriteAttributeValue("", 2809, item.ID, 2809, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2817, "\');", 2817, 3, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"layui-icon layui-icon-delete\"></i>删除</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 71 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    ");
#nullable restore
#line 74 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\AdminList.cshtml"
Write(Html.PartialAsync("_Pager", Model).Result);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>
<script>
    function AddOrEdit(id) {
        if (id == undefined) {
            ShowMaxWindow('===添加管理员信息===', '/System/AdminAdd');
        }
        else {
            ShowMaxWindow('===编辑管理员信息===', '/System/AdminAdd/' + id);
        }
    }

    //layui.use(['laydate'], function () {
    //    var laydate = layui.laydate
    //    //日期
    //    laydate.render({
    //        elem: '#StartTime'
    //    });
    //    laydate.render({
    //        elem: '#EndTime'
    //    });
    //});
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList<GetAdminListResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
