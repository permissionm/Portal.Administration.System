using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem
{
   public class CreateExecAppointment : DatabaseCommand
    {
        private readonly SqlParameter idParameter = new SqlParameter(@"ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter packageIDParameter = new SqlParameter(@"PackageID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter typeIDParameter = new SqlParameter(@"TypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter minutesOfAppointmentParameter = new SqlParameter(@"MinutesOfAppointment", SqlDbType.Int,4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        internal CreateExecAppointment() : base ("[dbo].[PortalExecPackageAppointment]")
            {
            SetParameters(
                         idParameter,
                         packageIDParameter,
                         typeIDParameter,
                         minutesOfAppointmentParameter
                         );

        }
        internal void SetOutPutParameters(
                                         out int Id
                                         )
        {
            Id = (int)idParameter.Value;
        }
        internal void SetInputParameters (
                                        int packageID,
                                        int typeID,
                                        int minutesOfAppointment
                                        )
        {
            packageIDParameter.Value = packageID;
            typeIDParameter.Value = typeID;
            minutesOfAppointmentParameter.Value = minutesOfAppointment;
        }
    }
}
