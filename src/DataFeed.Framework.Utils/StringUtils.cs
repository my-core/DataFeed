
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.Framework.Utils
{
    public class StringUtils
    {
        /// <summary>  
        /// 生成20位唯一的数字 并发可用  
        /// </summary>  
        /// <returns></returns>  
        public static string GenerateUniqueID()
        {
            System.Threading.Thread.Sleep(1); //保证yyyyMMddHHmmssffff唯一  
            Random d = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            string strUnique = DateTime.Now.ToString("yyyyMMddHHmmssffff") + d.Next(0, 99).ToString().PadLeft(2, '0');
            return strUnique;
        }
    }
}
