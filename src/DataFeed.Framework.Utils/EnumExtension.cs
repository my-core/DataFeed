using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace DataFeed.Framework.Utils
{
    public class EnumUtils
    {
        public static Dictionary<int, string> GetDescList<T>()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                object[] attrs = value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), true);
                string desc = string.Empty;
                if (attrs != null &&
                    attrs.Length > 0)
                {
                    DescriptionAttribute descAttr = attrs[0] as DescriptionAttribute;
                    desc = descAttr.Description;
                }
                dic.Add(Convert.ToInt32(value), desc);
            }
            return dic;
        }

        public static string GetDescription<T>(int value)
        {
            Dictionary<int, string> dic = GetDescList<T>();
            if (dic.ContainsKey(value))
            {
                return dic[value];
            }
            return "";
        }
    }
}
