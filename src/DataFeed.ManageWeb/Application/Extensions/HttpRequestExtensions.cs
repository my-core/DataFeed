using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.ManageWeb.Application.Extensions
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// 判断请求是否为Ajax请求
        /// Ajax请求的request headers里都会有一个key为x-requested-with，值为XMLHttpRequest的header
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public static bool IsAjax(this HttpRequest httpRequest)
        {
            bool result = false;
            var xreq = httpRequest.Headers.ContainsKey("x-requested-with");
            if (xreq)
            {
                result = httpRequest.Headers["x-requested-with"] == "XMLHttpRequest";
            }
            return result;
        }
    }
}
