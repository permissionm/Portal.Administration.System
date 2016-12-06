using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem
{
  public class CreateIcasConnectDatabaseCommand : DatabaseCommand
    {
        private readonly SqlParameter menuPDFIDParameter = new SqlParameter(@"MenuPDFID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter clientIDParameter = new SqlParameter(@"clientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter clientNameParameter = new SqlParameter(@"ClientName", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        
        internal CreateIcasConnectDatabaseCommand() : base("[dbo].[PortalAboutIcasConnect]")
        {
            SetParameters(
                            menuPDFIDParameter,
                            clientIDParameter,
                            clientNameParameter
                         );
        }
        internal void GetOutputParameters(
                                            out int Id
                                         )
        {
            Id = (int)menuPDFIDParameter.Value;
        }

        internal void SetInputParameters(
                                          int clientID,
                                          string clientName
                                        )
        {
            clientIDParameter.Value = clientID;
            clientNameParameter.Value = clientName;
        }
    }
}
