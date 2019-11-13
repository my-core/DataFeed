using FastNet.Framework.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FastNet.Framework.Dapper.Generator;

namespace TCM.Rich.DbBuilder.DapperExtension
{
    /// <summary>
    /// 实现Sql Server驱动仓储
    /// </summary>
    public class SqlServerRepository : BaseRepository, IBaseRepository
    {
        private string _connString { get; set; }
        public SqlServerRepository(string connString)
            : base(connString, new SqlServerGenerator())
        {
            _connString = connString;
        }
        /// <summary>
        /// OpenConnection
        /// </summary>
        /// <returns></returns>
        public override IDbConnection OpenConnection()
        {
            var conn = new SqlConnection(_connString);
            conn.Open();
            return conn;            
        }
    }
}
