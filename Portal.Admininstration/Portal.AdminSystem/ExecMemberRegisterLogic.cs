using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;


namespace Portal.AdminSystem
{
   public class ExecMemberRegisterLogic : DatabaseLogic
    {
        public ExecMemberRegisterLogic(string connectionString) : base(connectionString)
        {

        }

        public ExecMemberRegisterModel Find(int? ID)
        {
            string query = "Select * From ExecCareMemberRegister where ID =" + ID + "";
            return this.db.Query<ExecMemberRegisterModel>(query).SingleOrDefault();
        }

        public void UpdateMember(ExecMemberRegisterModel execMemberRegisterModel)
        {
            var sqlQuery =
            "UPDATE [dbo].[ExecCareMemberRegister]" +
            "SET [MemberID] = @MemberID, " +
            "[StatusID] = @StatusID, " +
            "[ExecPackageID]  = @ExecPackageID, " +
            "[EntryDate] = @EntryDate," +
            "[ExecRegionID] = @ExecRegionID," +
            "[BranchCode] = @BranchCode, " +
            "[EmployeeNumber] = @EmployeeNumber," +
            "[CostCenterNumber] = @CostCenterNumber " +
            "WHERE [ID] = @ID";
            this.db.Execute(sqlQuery, execMemberRegisterModel);
        }
    }
}