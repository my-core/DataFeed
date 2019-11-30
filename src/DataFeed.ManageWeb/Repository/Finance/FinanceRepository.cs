
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using DataFeed.Framework.Repository;
using DataFeed.ManageWeb.Contract.Response;
using FastNet.Framework.Dapper;
using DataFeed.ManageWeb.Contract.Request;
using DataFeed.Framework.Model;

namespace DataFeed.ManageWeb.Repository
{
    public class FinanceRepository : MySqlRepository, IFinanceRepository
    {
        public FinanceRepository(string connString) : base(connString) { }

    }
}
