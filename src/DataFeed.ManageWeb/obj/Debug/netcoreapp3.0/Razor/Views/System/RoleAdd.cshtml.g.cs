#pragma checksum "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleAdd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e77888109df17c4a6b73c60181947a336477797a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_System_RoleAdd), @"mvc.1.0.view", @"/Views/System/RoleAdd.cshtml")]
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
#line 1 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using FDataFeed.ManageWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using DataFeed.Framework.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using DataFeed.ManageWeb.Application.Pager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using DataFeed.ManageWeb.Contract.Response;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using DataFeed.ManageWeb.Contract.Base;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\_ViewImports.cshtml"
using FastNet.Framework.Dapper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e77888109df17c4a6b73c60181947a336477797a", @"/Views/System/RoleAdd.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b91a9f9eb8ea4f4704b373dad83ac5468f86b8c", @"/Views/_ViewImports.cshtml")]
    public class Views_System_RoleAdd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleInfo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("RoleAdd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-form layui-form-pane"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "System", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RoleAdd", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-mode", new global::Microsoft.AspNetCore.Html.HtmlString("replace"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-update", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("Post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("Callback"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<link href=\"/lib/zTree_v3/css/zTreeStyle/zTreeStyle.css\" rel=\"stylesheet\" />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e77888109df17c4a6b73c60181947a336477797a7297", async() => {
                WriteLiteral("\r\n    \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e77888109df17c4a6b73c60181947a336477797a7567", async() => {
                    WriteLiteral(@"

        <table class=""post-form"">
            <tr>
                <th style=""width: 150px;"">角色名：</th>
                <td>
                    <input id=""RoleName"" name=""RoleName"" lay-verify=""required"" lay-msg=""角色名不能为空"" class=""layui-input"" type=""text""");
                    BeginWriteAttribute("value", " value=\"", 656, "\"", 679, 1);
#nullable restore
#line 18 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleAdd.cshtml"
WriteAttributeValue("", 664, Model.RoleName, 664, 15, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <th>说明：</th>\r\n                <td>\r\n                    <textarea id=\"Description\" name=\"Description\" class=\"layui-input\">");
#nullable restore
#line 24 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleAdd.cshtml"
                                                                                 Write(Model.Description);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"</textarea>
                </td>
            </tr>
            <tr>
                <th>权限分配：</th>
                <td>
                    <div style=""width: 300px; height: 300px; overflow: scroll; border: solid 1px #d4d4d4;"">
                        <ul id=""TreePermission"" class=""ztree"" style=""width: 280px; overflow: auto;""></ul>
                    </div>
                    <input type=""hidden"" id=""PermissionIDs"" name=""PermissionIDs""");
                    BeginWriteAttribute("value", " value=\"", 1350, "\"", 1380, 1);
#nullable restore
#line 33 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleAdd.cshtml"
WriteAttributeValue("", 1358, ViewBag.PermissionIDs, 1358, 22, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <th></th>\r\n                <td>\r\n                    <button id=\"post_btn\" type=\"submit\" class=\"layui-btn\"");
                    BeginWriteAttribute("lay-submit", " lay-submit=\"", 1568, "\"", 1581, 0);
                    EndWriteAttribute();
                    WriteLiteral(" lay-filter=\"post\">保 存</button>\r\n                    <a href=\"javascript:void(0)\" onclick=\"parent.CloseWindow();\" class=\"layui-btn layui-btn-normal\">返回列表</a>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""/lib/zTree_v3/js/jquery.ztree.all.min.js""></script>
    <script>
        layui.use(['form'], function () {
            var form = layui.form;

            //监听提交
            form.on('submit(post)', function (data) {
                console.log(JSON.stringify(data.field));
                return true;
            });
        });
        //ZTree配置
        var setting = {
            check: {
                enable: true
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                onCheck: getAllCheckNodes
            }
        };

        $(function () {
            //ZTree初始化
            var json = '");
#nullable restore
#line 73 "E:\test\DataFeed\src\DataFeed.ManageWeb\Views\System\RoleAdd.cshtml"
                   Write(Html.Raw( ViewBag.PermissionList));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
            if (json == '')
                return;
            setting.check.chkboxType = { ""Y"": ""p"", ""N"": ""s"" };//被勾选时[关联父]，取消勾选时[关联子]
            $.fn.zTree.init($(""#TreePermission""), setting, eval(json));
            var treeObj = $.fn.zTree.getZTreeObj(""TreePermission"");
            treeObj.expandAll(true);
        });

        //获取所有选中的值
        function getAllCheckNodes() {
            var treeObj = $.fn.zTree.getZTreeObj('TreePermission'),
                    nodes = treeObj.getCheckedNodes(true),
                    v = '';
            for (var i = 0; i < nodes.length; i++) {
                if (v != '')
                    v += ',';
                v += nodes[i].value;
            }
            $('#PermissionIDs').val(v);
        }
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591