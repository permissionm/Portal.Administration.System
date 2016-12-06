using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem
{
   public class CreateExecClientDatabaseCommand : DatabaseCommand
    {
        private readonly SqlParameter usergroupIDParameter = new SqlParameter(@"UsergroupID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter desriptionParameter = new SqlParameter(@"Description", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);

        internal CreateExecClientDatabaseCommand() : base("[dbo].[PortalExecUsergroup]")
        {
            SetParameters(
                            usergroupIDParameter,
                            desriptionParameter
                          );
        }
        internal void GetOutputParameters(
                                        out int Id
                                     )
        {
            Id = (int)usergroupIDParameter.Value;
        }
        internal void SetInputParameters(
                                            string description                                
                                         )
        {
            desriptionParameter.Value = description;
        }
    }
}