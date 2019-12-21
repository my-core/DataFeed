
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using DataFeed.Framework.Repository;

namespace DataFeed.ManageWeb.Repository
{
    public class FinanceRepository : MySqlRepository, IFinanceRepository
    {
        public FinanceRepository(string connString) : base(connString) { }

    }
}
