using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
    class ExecCarePackagesLogic : DatabaseLogic
    {
        public ExecCarePackagesLogic(string connectionString) : base(connectionString)
        {

        }

        public ExecCarePackagesModel Find(int? ID)
        {
            string query = "Select * From ExecCarePackages where ID =" + ID + "";
            return this.db.Query<ExecCarePackagesModel>(query).SingleOrDefault();
        }

        public void UpdateExecPackage(ExecCarePackagesModel execPackage)
        {
            try
            {
                db.Open();
                db.Execute("PortalExecUpdatePackages", execPackage, commandType: CommandType.StoredProcedure);
                db.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", ID);
                db.Open();
                db.Execute("PortalDeletePackage", param, commandType: CommandType.StoredProcedure);
                db.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
