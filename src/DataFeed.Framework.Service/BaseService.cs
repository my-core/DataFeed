
using System;
using System.Collections.Generic;
using System.Linq;
using FastNet.Framework.Dapper;

namespace DataFeed.Framework.Service
{
    /// <summary>
    /// 服务基类
    /// </summary>
    public class BaseService : IBaseService
    {
        private IBaseRepository _baseRepository { get; set; }
        public BaseService(IBaseRepository baseRepository)
        {
            this._baseRepository = baseRepository;
        }

        #region ---insert---
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public long Insert<T>(T t)
        {
                return _baseRepository.Insert(t);
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public long Insert<T>(List<T> listT)
        {
                return _baseRepository.Insert(listT);
        }
        #endregion

        #region ---update---
        /// <summary>
        /// 按主键更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update<T>(T t)
        {
                return _baseRepository.Update(t) > 0;
        }
        /// <summary>
        /// 按指定条件更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update<T>(T t,object param)
        {
                return _baseRepository.Update(t, param) > 0;
        }
        #endregion

        #region ---delete---
        /// <summary>
        /// 按指定条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Delete<T>()
        {
                return _baseRepository.Delete<T>() > 0;
        }

        /// <summary>
        /// 按指定条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Delete<T>(object param)
        {
                return _baseRepository.Delete<T>(param) > 0;
        }
        #endregion

        #region ---GetModel---
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public T GetModel<T>(object param)
        {
                return _baseRepository.GetModel<T>(param);
        }
        #endregion

        #region
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int GetCount<T>(object param)
        {
                return _baseRepository.GetCount<T>(param);
        }

        #endregion

        #region ---GetList---
        
        /// <summary>
        /// 全表查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> GetList<T>()
        {
                return _baseRepository.GetList<T>();
        }
        /// <summary>
        /// 按指定条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> GetList<T>(object param)
        {
                return _baseRepository.GetList<T>(param);
        }
        #endregion

        #region ---GetPageList---
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public PagedList<T> GetPageList<T>(int pageIndex, int pageSize, string orderBy)
        {
                return _baseRepository.GetPagedList<T>(pageIndex, pageSize, orderBy);
        }
        #endregion
    }
}
