using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Utilities.SQL.Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Portal.AdminSystem
{
    public class DatabaseLogic
    {
        public string ConnectionString { get; set; }

        protected IDbConnection db;
        public DatabaseLogic(string connectionString)
        {
            ConnectionString = connectionString;
            db = new SqlConnection(ConnectionString);
        }
    }
}
