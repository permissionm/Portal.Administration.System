using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
   public class ExecClientUsergroupsLogic : DatabaseLogic
    {
        public ExecClientUsergroupsLogic(string connectionString) : base(connectionString)
        {

        }

        public ExecClientUsergroups Find(int? UsergroupID)
        {
            string query = "Select * From Usergroup where UsergroupID =" + UsergroupID + "";
            return this.db.Query<ExecClientUsergroups>(query).SingleOrDefault();
        }

        public void UpdateExecUsergroup(ExecClientUsergroups execClientUsergroups )
        {
            var sqlQuery =
                "UPDATE [HealthManagement].[dbo].[Usergroup]" +
                 "SET [Description] = @Description, " +
                 "[Email] = @Email, " +
                 "[TrialPeriod] = @TrialPeriod," +
                 "[Priority] = @Priority, " +
                 "[Grouping] = @Grouping, " +       
                 "[Principal] = @Principal, " +
                 "[DisplayName] = @DisplayName " +
                 "WHERE UsergroupID = @UsergroupID";
            this.db.Execute(sqlQuery, execClientUsergroups);
        }
    }
}
