using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem.DataAccess
{
   public class CreateClientDatabaseCommand : DatabaseCommand
    {
        private readonly SqlParameter clientNameParameter = new SqlParameter(@"ClientName", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter clientMailAliasParameter = new SqlParameter(@"ClientMailAlias", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter displayNameParameter = new SqlParameter(@"DisplayName", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        internal CreateClientDatabaseCommand() : base("[dbo].[PortalClientsCreate]")
        {
            SetParameters(
                            clientNameParameter,
                            clientMailAliasParameter,
                            displayNameParameter
                          );
        }

        internal void SetInputParameters(
                                            string clientName,
                                            string ClientMailAlias,
                                            string displayName
                                         )
        {
            clientNameParameter.Value = clientName;
            clientMailAliasParameter.Value = ClientMailAlias;
            displayNameParameter.Value = displayName;
        }
    }
}

