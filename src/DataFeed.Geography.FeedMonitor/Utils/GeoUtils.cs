using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Geography.FeedMonitor.Utils
{
    public static class GeoUtils
    {
        public static Dictionary<string, string> dic = new Dictionary<string, string>();
        static GeoUtils()
        {
            dic.Add("北京", "京");
            dic.Add("天津", "津");
            dic.Add("河北", "冀");
            dic.Add("山西", "晋");
            dic.Add("内蒙古", "蒙");
            dic.Add("辽宁", "辽");
            dic.Add("吉林", "吉");
            dic.Add("黑龙江", "黑");
            dic.Add("上海", "沪");
            dic.Add("江苏", "苏");
            dic.Add("浙江省", "浙");
            dic.Add("安徽", "皖");
            dic.Add("福建", "闽");
            dic.Add("江西", "赣");
            dic.Add("山东", "鲁");
            dic.Add("河南", "豫");
            dic.Add("湖北", "鄂");
            dic.Add("湖南", "湘");
            dic.Add("广东", "粤");
            dic.Add("广西", "桂");
            dic.Add("海南", "琼");
            dic.Add("重庆", "渝");
            dic.Add("四川", "川");
            dic.Add("贵州", "黔");
            dic.Add("云南", "滇");
            dic.Add("西藏", "藏");
            dic.Add("陕西", "陕");
            dic.Add("甘肃省", "甘");
            dic.Add("青海", "青");
            dic.Add("宁夏", "宁");
            dic.Add("新疆", "新");
            dic.Add("台湾", "台");
            dic.Add("香港特别行政区", "港");
            dic.Add("澳门", "澳");
        }

        /// <summary>
        /// 获取省简称
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns></returns>
        public static string GetShortName(string provinceName)
        {
            foreach(string key in dic.Keys)
            {
                if (provinceName.Contains(key))
                {
                    return dic[key];
                }
            }
            return "";
        }
    }


}
