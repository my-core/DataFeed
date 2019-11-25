using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.ManageWeb.Application.Filter
{
    /// <summary>
    /// 全局action拦截
    /// </summary>
    public class GlobalActionFilterAttribute : ActionFilterAttribute
    {
        private ILogger logger;
        public GlobalActionFilterAttribute(ILogger<GlobalActionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// 执行前
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            string requestPath = string.Format("{0}/{1}", controller, action);
            var actionArguments = JsonConvert.SerializeObject(context.ActionArguments);
            logger.LogInformation("Request Start->RequestPath:{0},ActionArguments:{1}", requestPath, actionArguments);
            base.OnActionExecuting(context);
        }
        /// <summary>
        /// 执行后
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            string requestPath = string.Format("{0}/{1}", controller, action);
            string response = JsonConvert.SerializeObject(context.Result);
            logger.LogInformation("Request End->RequestPath:{0},Response:{1}", requestPath, response);
            base.OnActionExecuted(context);
        }
    }
}
