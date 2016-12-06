using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem
{
   public class CreateExecCareUsersDatabaseCommand : DatabaseCommand
    {
        private readonly SqlParameter execNameParameter = new SqlParameter(@"ExecName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter execSurnameParameter = new SqlParameter(@"ExecSurname", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter execEmailParameter = new SqlParameter(@"ExecEmail", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter execPasswordParameter = new SqlParameter(@"ExecPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter typeIDParameter = new SqlParameter(@"TypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter execRegionIDParameter = new SqlParameter(@"ExecRegionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        internal CreateExecCareUsersDatabaseCommand() : base("[dbo].[PortalExecUsers]")
        {
            SetParameters(
                           execNameParameter,
                           execSurnameParameter,
                           execEmailParameter,
                           execPasswordParameter,
                           typeIDParameter,
                           execRegionIDParameter
                         );
        }
        internal void SetInputParameters(
                                            string name,
                                            string surname,
                                            string email,
                                            string password,
                                            int typeID,
                                            int regionID
                                         )
        {
            execNameParameter.Value = name;
            execSurnameParameter.Value = surname;
            execEmailParameter.Value = email;
            execPasswordParameter.Value = password;
            typeIDParameter.Value = typeID;
            execRegionIDParameter.Value = regionID;
        }
    }
}