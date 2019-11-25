using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataFeed.ManageWeb.Application.Middleware
{
    /// <summary>
    /// IP过滤中间件(黑白名单)
    /// </summary>
    public class FilterIPMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly FilterIPMiddlewareOption _option;

        public FilterIPMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, FilterIPMiddlewareOption option)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<FilterIPMiddleware>();
            _option = option;
        }

        public async Task Invoke(HttpContext context)
        {
            string userIP = context.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation("UserIP:" + userIP);
            //验证ip
            //if (!_option.Ips.Contains(userIP)
            //{

            //}
            await _next.Invoke(context);
        }
    }

    /// <summary>
    /// 扩展
    /// </summary>
    public static class RequestIPExtensions
    {
        public static IApplicationBuilder UseFilterIP(this IApplicationBuilder builder, FilterIPMiddlewareOption option)
        {
            return builder.UseMiddleware<FilterIPMiddleware>(option);
        }
    }

    /// <summary>
    /// 中间件选项
    /// </summary>
    public class FilterIPMiddlewareOption
    {
        public List<string> Ips { get; set; }
    }
}
