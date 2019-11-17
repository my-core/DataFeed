using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFeed.Finance.WebApi.Contract.Response
{
    /// <summary>
    /// 接口响应基类
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// 请求是成功
        /// </summary>
        public bool IsOK { get; set; } = true;
        /// <summary>
        /// 消息码(200- 成功 500-服务异常)
        /// </summary>
        public int Code { get; set; } = 200;
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; } = "success";
    }

    /// <summary>
    /// 接口响应基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T> : ApiResponse
    {
        /// <summary>
        ///  响应数据
        /// </summary>
        public T Data { get; set; }
    }
}
