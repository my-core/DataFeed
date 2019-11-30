#pragma checksum "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e7b5f8c507d206af8672f3e5f60c8a2e3a92539"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_System_RoleList), @"mvc.1.0.view", @"/Views/System/RoleList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e7b5f8c507d206af8672f3e5f60c8a2e3a92539", @"/Views/System/RoleList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b91a9f9eb8ea4f4704b373dad83ac5468f86b8c", @"/Views/_ViewImports.cshtml")]
    public class Views_System_RoleList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList<GetRoleListResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
  
    ViewBag.Title = "角色列表";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n");
#nullable restore
#line 7 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
     using (Html.BeginForm("RoleList", "System", FormMethod.Get, new { @class = "layui-form search-form layui-elem-quote", @id = "searchForm" }))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <table>\r\n            <tr>\r\n                <th>名称：</th>\r\n                <td>\r\n                    <input id=\"RoleName\" name=\"RoleName\" class=\"layui-input\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 431, "\"", 439, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </td>\r\n                <td>\r\n                    <input type=\"submit\" class=\"layui-btn layui-btn-sm\" value=\"查 询\" />\r\n                </td>\r\n            </tr>\r\n        </table>\r\n");
#nullable restore
#line 20 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div style=""padding:0px 10px;"">
            <a class=""layui-btn layui-btn-sm layui-btn-normal"" href=""javascript:void(0);"" onclick=""AddOrEdit()"">
                <i class=""layui-icon layui-icon-tianjia2""></i>添加角色</a>
        </div>
    <table class=""layui-table"" id=""list"">
        <thead>
            <tr>
                <th style=""width:45px; text-align:center;"">#</th>
                <th>角色ID</th>
                <th>角色名</th>
                <th>备注</th>
                <th>创建人</th>
                <th>创建时间</th>
                <th>操作</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 38 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
               int index = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td style=\"width:45px; text-align:center;\">");
#nullable restore
#line 42 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
                                                           Write(index++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 43 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
                   Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 44 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
                   Write(item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 45 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 46 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
                   Write(item.CreateAdmin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 47 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
                   Write(item.CreateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a class=\"layui-btn layui-btn-normal layui-btn-xs\" href=\"javascript:void(0)\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1809, "\"", 1840, 3);
            WriteAttributeValue("", 1819, "AddOrEdit(\'", 1819, 11, true);
#nullable restore
#line 49 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
WriteAttributeValue("", 1830, item.ID, 1830, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1838, "\')", 1838, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"layui-icon layui-icon-bianji\"></i>编辑</a>\r\n                        <a class=\"layui-btn layui-btn-danger layui-btn-xs\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1968, "\"", 2027, 3);
            WriteAttributeValue("", 1978, "javascript:Delete(\'/System/RoleDelete/", 1978, 38, true);
#nullable restore
#line 50 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
WriteAttributeValue("", 2016, item.ID, 2016, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2024, "\');", 2024, 3, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"layui-icon layui-icon-delete\"></i>删除</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 53 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    ");
#nullable restore
#line 56 "F:\学习Demo\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleList.cshtml"
Write(Html.Partial("_Pager", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>
<script>
    function AddOrEdit(id) {
        if (id == undefined) {
            ShowMaxWindow('===添加角色信息===', '/System/RoleAdd');
        }
        else {
            ShowMaxWindow('===编辑角色信息===', '/System/RoleAdd/' + id);
        }
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList<GetRoleListResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
