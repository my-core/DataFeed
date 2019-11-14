using FastNet.Framework.Dapper;
using FastNet.Framework.Dapper.Generator;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataFeed.Geography.FeedMonitor
{
    public class MySqlRepository : BaseRepository, IBaseRepository
    {
        private string _connString { get; set; }
        public MySqlRepository(string connString)
            : base(connString, new MySqlGenerator())
        {
            _connString = connString;
        }
        /// <summary>
        /// OpenConnection
        /// </summary>
        /// <returns></returns>
        public override IDbConnection OpenConnection()
        {
            var conn = new MySqlConnection(_connString);
            conn.Open();
            return conn;            
        }
    }
}
