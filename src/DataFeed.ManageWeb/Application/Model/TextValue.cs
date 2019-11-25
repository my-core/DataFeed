using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFeed.ManageWeb.Application.Models
{
    /// <summary>
    /// 用于下拉框的绑定数据源
    /// </summary>
    public class TextValue
    {
        public string Text { get; set; }
        public object Value { get; set; }
    }
}