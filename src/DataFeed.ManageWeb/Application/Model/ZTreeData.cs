using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFeed.ManageWeb.Application.Models
{
    /// <summary>
    /// 用于Ztree插件绑定的数据源
    /// </summary>
    public class ZTreeData
    {
        public int id { get; set; }
        public int pId { get; set; }
        public string name { get; set; }
        public int value { get; set; }
        [JsonProperty("checked")]
        public bool Checked { get; set; }
    }
}