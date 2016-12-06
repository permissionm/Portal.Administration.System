using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
    public class ClientLogic : DatabaseLogic
    {
        public ClientLogic(string connectionString) : base(connectionString)
        {

        }

        public ClientModel Find(int? ClientID)
        {
            string query = "Select * From Client where ClientID =" + ClientID + "";
            return this.db.Query<ClientModel>(query).SingleOrDefault();
        }

        public void UpdateClient(ClientModel clientModel)
        {
            try
            {
                db.Open();
                db.Execute("PortalUpdateClient", clientModel, commandType: CommandType.StoredProcedure);
                db.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int ClientID)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ClientID", ClientID);
                db.Open();
                db.Execute("PortalDeleteClientById", param, commandType: CommandType.StoredProcedure);
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
