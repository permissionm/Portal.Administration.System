using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
  public  class UsergroupLogic : DatabaseLogic
    {
        public UsergroupLogic(string connectionString) : base(connectionString)
        {

        }

        public UsergroupsModel Find(int? UsergroupID)
        {
            string query = "Select * From Usergroup where UsergroupID =" + UsergroupID + "";
            return this.db.Query<UsergroupsModel>(query).SingleOrDefault();
        }

        public void UpdateUsergroup(UsergroupsModel usergroupsModel)
        {
            var sqlQuery =
               "Update[dbo].[Usergroup]" +
               "SET Description = @Description, " +
               "Priority = @Priority, " +
               "UsergroupUsageID = @UsergroupUsageID, " +
               "ReportingLevel = @ReportingLevel," +
               "ParentID = @ParentID, " +
               "LookupValueID = @LookupValueID " +
               "WHERE UsergroupID = @UsergroupID";
            this.db.Execute(sqlQuery, usergroupsModel);
        }

        public bool Delete(int UsergroupID)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UsergroupID", UsergroupID);
                db.Open();
                db.Execute("PortalDeleteUsergroupById", param, commandType: CommandType.StoredProcedure);
                db.Close();
                return true;
            }
            catch
            {
                throw ;
            }
        }
    }
}