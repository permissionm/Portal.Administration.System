using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
    public class MemberLogic : DatabaseLogic
    { 
       public MemberLogic(string connectionString) : base(connectionString)
        {

        }

        public MemberModel Find(int? MemberID)
        {
            string query = "Select * From Members where MemberID =" + MemberID + "";
            return this.db.Query<MemberModel>(query).SingleOrDefault();
        }

        public void UpdateMember(MemberModel memberModel)
        {
            var sqlQuery =
            "Update[GlobalPortalMembers].[dbo].[Members]" +
            "SET [Email] = @Email, " +
            "[Username] = @Username, " +
            "[Name] = @Name, " +
            "[Surname] = @Surname," +
            "[WlcSent] = @WlcSent," +
            "[Active] = @Active " +
            "WHERE [MemberID] = @MemberID";
            this.db.Execute(sqlQuery, memberModel);
        }
    } 
}


