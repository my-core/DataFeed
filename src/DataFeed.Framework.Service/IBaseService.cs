
using FastNet.Framework.Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataFeed.Framework.Service
{
    /// <summary>
    /// 服务基类
    /// </summary>
    public interface IBaseService
    {
        #region ---insert---
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        long Insert<T>(T t);
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        long Insert<T>(List<T> listT);
        #endregion

        #region ---update---
        /// <summary>
        /// 按主键更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update<T>(T t);
        /// <summary>
        /// 按指定条件更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update<T>(T t, object param);
        #endregion

        #region ---delete---
        /// <summary>
        /// 按指定条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Delete<T>();

        /// <summary>
        /// 按指定条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Delete<T>(object param);
        #endregion

        #region ---GetModel---
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T GetModel<T>(object param);
        #endregion

        #region
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        int GetCount<T>(object param);
        #endregion

        #region ---GetList---

        /// <summary>
        /// 全表查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        List<T> GetList<T>();
        /// <summary>
        /// 按指定条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        List<T> GetList<T>(object param);
        #endregion

        #region ---GetPageList---
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        PagedList<T> GetPageList<T>(int pageIndex, int pageSize, string orderBy);
        #endregion

    }
}
