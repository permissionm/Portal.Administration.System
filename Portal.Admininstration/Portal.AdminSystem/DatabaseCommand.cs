using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem
{
    public class DatabaseCommand : IDisposable
    {
        protected DatabaseCommand(string commandText)
        {
            Command = new SqlCommand(commandText) { CommandType = CommandType.StoredProcedure };
        }

        internal const int DefaultCommandTimeout = -1;

        protected void SetParameters(params SqlParameter[] parameters)
        {
            Command.Parameters.AddRange(parameters);
        }
        internal SqlConnection Connection
        {
            set { Command.Connection = value; }
        }
        internal SqlTransaction Transaction
        {
            set { Command.Transaction = value; }
        }
        internal int CommandTimeout
        {
            set
            {
                if (value == DefaultCommandTimeout)
                {
                    Command.ResetCommandTimeout();
                }
                else
                {
                    Command.CommandTimeout = value;
                }
            }
        }
        internal int ExecuteNonQuery()
        {
            Prepare();
            return Command.ExecuteNonQuery();
        }
        internal SqlDataReader ExecuteReader()
        {
            Prepare();
            return Command.ExecuteReader();
        }
        private void Prepare()
        {
            var connection = Command.Connection;

            if ((connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        internal void Dispose(bool disposing)
        {
            if (disposing)
            {
                Command.Dispose();
            }
        }
        public SqlCommand Command { get; }
    }
}
