using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem
{
   public class CreateExecPackageDatabaseCommand : DatabaseCommand
    {
        private readonly SqlParameter idParameter = new SqlParameter(@"ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter descriptionParameter = new SqlParameter(@"Description", SqlDbType.NVarChar, 100,ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter streamParameter = new SqlParameter(@"Stream", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        internal CreateExecPackageDatabaseCommand() : base("[dbo].[PortalExecPackages]")
        {
            SetParameters(
                         idParameter,
                         descriptionParameter,
                         streamParameter
                         );

        }
        internal void GetOutputParameters(
                                          out int Id
                                         )
        {
            Id = (int)idParameter.Value;
        }
        internal void SetInputParameters(
                                          string description,
                                          int stream
                                        )
        {
            descriptionParameter.Value = description;
            streamParameter.Value = stream;
        }
    }
}
