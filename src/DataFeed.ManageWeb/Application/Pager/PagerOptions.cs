
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.ManageWeb.Application.Pager
{
    public class PagerOptions
    {
        public PagerOptions()
        {

        }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 记录总数
        /// </summary>
        public int TotalRecordCount { get; set; }

        /// <summary>
        /// 标签元素ID
        /// </summary>
        public string TagID = "Pager";
        public string FirstPageText = "首页";
        public string LastPageText = "末页";
        public string PrevPageText = "上一页";
        public string NextPageText = "下一页";
        
        /// <summary>
        /// 获取或设置数字页索引分页按钮数目
        /// </summary>
        public int NumericPagerItemCount = 10;
    }
}
