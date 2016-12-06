using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem
{
    public class CreateUsergroupsDatabaseCommand : DatabaseCommand
    {
        private readonly SqlParameter usergroupIDParameter = new SqlParameter(@"UsergroupID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter iDParameter = new SqlParameter(@"ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter descriptionParameter = new SqlParameter(@"Description", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter clientIDParameter = new SqlParameter(@"ClientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
     
        internal CreateUsergroupsDatabaseCommand() : base("[dbo].[PortalCreateUsergroupLink]")
        {
            SetParameters(
                            usergroupIDParameter,
                            iDParameter,
                            descriptionParameter,
                            clientIDParameter
                          );
        }
        internal void GetOutputParameters(
                                            out int Id,
                                            out int Idpar
                                         )
        {
            Id = (int)usergroupIDParameter.Value;
            Idpar = (int)iDParameter.Value;
            
        }

        internal void SetInputParameters(
                                            string description,
                                            int clientID

                                         )
        {
            descriptionParameter.Value = description;
            clientIDParameter.Value = clientID;
        }
    }
}