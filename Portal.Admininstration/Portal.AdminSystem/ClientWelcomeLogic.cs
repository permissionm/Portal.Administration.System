using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
    public class ClientWelcomeLogic : DatabaseLogic
    {
        public ClientWelcomeLogic(string connectionString) : base(connectionString)
        {

        }

        public ClientWelcomeModel Find(int? Template_ClientID)
        {
            string query = "Select * From TblWelcomeTemplate_Client where Template_ClientID =" + Template_ClientID + "";
            return this.db.Query<ClientWelcomeModel>(query).SingleOrDefault();
        }

        public void UpdateWelcome(ClientWelcomeModel clientWelcomeModel)
        {
            var sqlQuery =
            "UPDATE [dbo].[TblWelcomeTemplate_Client] " +
            "SET TemplateID = @TemplateID, " +
            "ClientID = @ClientID " +
            "WHERE Template_ClientID = @Template_ClientID";
            this.db.Execute(sqlQuery, clientWelcomeModel);
        }
    }
}
