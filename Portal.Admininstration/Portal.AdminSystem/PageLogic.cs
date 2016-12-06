using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
    public class PageLogic : DatabaseLogic
    {
        public PageLogic(string connectionString) : base(connectionString)
        {

        }

        public ClientPage Find(int? ClientSettingID)
        {
            string query = "Select * FROM Client_PageTemplate where ClientSettingID =" + ClientSettingID + "";
            return this.db.Query<ClientPage>(query).SingleOrDefault();
        }

        public void UpdateClientPage(ClientPage clientPage)
        {
            var sqlQuery =
               "UPDATE [dbo].[Client_PageTemplate]" +
               "SET  [PageTemplateType_LinkID] = @PageTemplateType_LinkID, " +  
               "[ClientID] = @ClientID " +
               "WHERE ClientSettingID = @ClientSettingID";
            this.db.Execute(sqlQuery, clientPage);
        }
    }
}