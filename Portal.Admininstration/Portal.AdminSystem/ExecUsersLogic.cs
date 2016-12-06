using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
   public class ExecUsersLogic : DatabaseLogic
    {
        public ExecUsersLogic(string connectionString) : base(connectionString)
        {

        }

        public ExecUsersModel Find(int? ExecUserID)
        {
            string query = "Select * From ExecCareUsers where ExecUserID =" + ExecUserID + "";
            return this.db.Query<ExecUsersModel>(query).SingleOrDefault();
        }

        public void UpdateExecUsers(ExecUsersModel execUsersModel)
        {
            var sqlQuery =
            "Update [HealthManagement].[dbo].[ExecCareUsers]" +
            "SET [ExecName] = @ExecName, " +
			"[ExecSurname] = @ExecSurname, " +
			"[ExecEmail] = @ExecEmail, " +
			"[ExecUsername] = @ExecUsername, " +
			"[ExecPassword] = @ExecPassword, " +
		    "[Active] = @Active, " +
			"[TypeID] = @TypeID, " +
			"[IsDefault] = @IsDefault " +
            "WHERE [ExecUserID] = @ExecUserID";
            this.db.Execute(sqlQuery, execUsersModel);
        }
    }
}
