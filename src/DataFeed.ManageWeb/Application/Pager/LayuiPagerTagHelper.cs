
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.ManageWeb.Application.Pager
{
    /// <summary>
    /// 分页标签
    /// </summary>
    [HtmlTargetElement("laypager", TagStructure = TagStructure.WithoutEndTag)]
    public class LayuiPagerTagHelper : TagHelper
    {
        /// <summary>
        /// http上下文
        /// </summary>
        private readonly HttpContext _httpContext;

        /// <summary>
        /// action上下文
        /// </summary>
        private readonly ActionContext _actionContext;

        /// <summary>
        /// Context for view execution.
        /// </summary>
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        /// <summary>
		/// Get or set the options for the pager
		/// </summary>
		[HtmlAttributeName("options")]
        public PagerOptions Options { get; set; }

        /// <summary>
        /// 构造函数 注入上下文
        /// </summary>
        /// <param name="accessor"></param>
        public LayuiPagerTagHelper(IHttpContextAccessor accessor, IActionContextAccessor actionContextAccessor)
        {
            _httpContext = accessor.HttpContext;
            _actionContext = actionContextAccessor.ActionContext;
        }

        /// <summary>
        /// 重写Tag Process
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            if (Options.PageIndex <= 0) { Options.PageIndex = 1; }
            if (Options.PageSize <= 0) { Options.PageSize = 10; }
            if (Options.TotalRecordCount <= 0) { return; }

            //总页数
            var totalPage = (int)Math.Ceiling(Options.TotalRecordCount / (double)Options.PageSize);
            if (totalPage <= 0) { return; }
            //当前路由地址
            //string controllerName = _actionContext.RouteData.Values["controller"].ToString();
            //string actionName = _actionContext.RouteData.Values["action"].ToString();
            //_actionContext.HttpContext.Request.Path;

            //构造分页样式
            var sbPage = new StringBuilder(string.Empty);
            sbPage.AppendFormat("<div class=\"layui-box layui-laypage layui-laypage-default\" id=\"{0}\">", Options.TagID);
            sbPage.AppendFormat("<span class=\"layui-laypage-count\">共 {0} 条,每页 {1} 条,共 {2} 页</span>", Options.TotalRecordCount, Options.PageSize, totalPage);
            if (Options.PageIndex > 1)
            {
                //首页
                sbPage.AppendFormat("<a href=\"{0}\" class=\"layui-laypage-first\">{1}</a>", GetPagerUrl(1), Options.FirstPageText);
                //上一页
                int prevPageIndex = ((Options.PageIndex - 1 > 0) ? (Options.PageIndex - 1) : 1);
                sbPage.AppendFormat("<a href=\"{0}\" class=\"layui-laypage-prev\">{1}</a>",
                     GetPagerUrl(prevPageIndex),
                    Options.PrevPageText);
            }
            else
            {
                //首页
                sbPage.AppendFormat("<a href=\"javascript:;\" class=\"layui-laypage-first layui-disabled\">{0}</a>", Options.FirstPageText);
                //上一页
                sbPage.AppendFormat("<a href=\"javascript:;\" class=\"layui-laypage-prev layui-disabled\">{0}</a>", Options.PrevPageText);
            }
            //分页页码
            int start = 1;
            int end = totalPage;
            if (totalPage > Options.NumericPagerItemCount)
            {
                start = Options.PageIndex - Options.NumericPagerItemCount;
                end = Options.PageIndex + Options.NumericPagerItemCount;
                if (start <= 0)
                    start = 1;
                if (end > totalPage)
                    end = totalPage;
            }
            for (int i = start; i <= end; i++)
            {
                if (Options.PageIndex == i)
                {
                    sbPage.AppendFormat("<span class='layui-laypage-curr'><em class='layui-laypage-em'></em><em>{0}</em></span>", i);
                }
                else
                {
                    sbPage.AppendFormat("<a href=\"{0}\">{1}</a>", GetPagerUrl(i), i);
                }
            }
            if (Options.PageIndex < totalPage)
            {
                //下一页
                int nextPageIndex = ((Options.PageIndex >= totalPage) ? Options.PageIndex : (Options.PageIndex + 1));
                sbPage.AppendFormat("<a href=\"{0}\" class=\"layui-laypage-next\">{1}</a>", GetPagerUrl(nextPageIndex), Options.NextPageText);
                //尾页
                sbPage.AppendFormat("<a href=\"{0}\" class=\"layui-laypage-last\">{1}</a>", GetPagerUrl(totalPage), Options.LastPageText);
            }
            else
            {
                //下一页
                sbPage.AppendFormat("<a href=\"javascript:;\" class=\"layui-laypage-next layui-disabled\">{0}</a>", Options.NextPageText);
                //尾页
                sbPage.AppendFormat("<a href=\"javascript:;\" class=\"layui-laypage-last layui-disabled\">{0}</a>", Options.LastPageText);
            }
            sbPage.AppendFormat("<a href=\"{0}\" class=\"layui-laypage-refresh\"><i class=\"layui-icon layui-icon-refresh\"></i></a>", GetPagerUrl(Options.PageIndex));
            sbPage.Append("</div>");
            output.PostElement.SetHtmlContent(sbPage.ToString());
            //base.Process(context, output);
        }

        private string GetPagerUrl(int currentPageIndex)
        {
            HttpRequest request = _actionContext.HttpContext.Request;
            string urlParams = string.Format("PageIndex={0}&PageSize={1}", currentPageIndex, Options.PageSize);
            foreach (var key in request.Query.Keys)
            {
                if (key.ToLower() == "pageindex" || key.ToLower() == "pagesize")
                {
                    continue;
                }

                urlParams += "&" + key + "=" + request.Query[key];
            }
            return string.Format("{0}?{1}", request.Path, urlParams);
        }
    }
}
