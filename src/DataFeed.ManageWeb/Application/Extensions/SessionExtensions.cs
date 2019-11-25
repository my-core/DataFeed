
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFeed.ManageWeb.Application.Extensions
{
    /// <summary>
    /// Session扩展
    /// </summary>
    public static class SessionExtensions
    {
        #region ---Set Session---
        public static void Set(this ISession session, string key, string value)
        {
            session.SetString(key, value);
        }

        public static void Set(this ISession session, string key, int value)
        {
            session.SetInt32(key, value);
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        #endregion

        #region ---Get Session---
        public static string Get(this ISession session, string key, string defaultValue = "")
        {
            string value = session.GetString(key);
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        public static int Get(this ISession session, string key, int defaultValue = -1)
        {
            int? value = session.GetInt32(key);
            return value ?? defaultValue;
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        #endregion
    }
}
