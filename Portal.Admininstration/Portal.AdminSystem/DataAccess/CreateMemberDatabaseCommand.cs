using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem
{
    public class CreateMemberDatabaseCommand : DatabaseCommand
    {
        private readonly SqlParameter emailParameter = new SqlParameter(@"Email", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter usernameParameter = new SqlParameter(@"Username", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter nameParameter = new SqlParameter(@"Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter surnameParameter = new SqlParameter(@"Surname", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter clientIDParameter = new SqlParameter(@"ClientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter usergroupIDParameter = new SqlParameter(@"UsergroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);

        internal CreateMemberDatabaseCommand() : base("[dbo].[PortalCreateMember]")
        {
            SetParameters(
                            emailParameter,
                            usernameParameter,
                            nameParameter,
                            surnameParameter,
                            clientIDParameter,
                            usergroupIDParameter
                         );
        }
        internal void SetInputParameters(
                                            string email,
                                            string username,
                                            string name,
                                            string surname,
                                            int clientID,
                                            int usergroupID

                                         )
        {
            emailParameter.Value = email;
            usernameParameter.Value = username;
            nameParameter.Value = name;
            surnameParameter.Value = surname;
            clientIDParameter.Value = clientID;
            usergroupIDParameter.Value = usergroupID;
        }
    }
}

