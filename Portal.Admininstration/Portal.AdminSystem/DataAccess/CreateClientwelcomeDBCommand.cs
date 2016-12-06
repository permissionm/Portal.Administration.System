using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem.DataAccess
{
   public class CreateClientwelcomeDBCommand  : DatabaseCommand
    {
        private readonly SqlParameter template_ClientIDParameter = new SqlParameter(@"Template_ClientID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter clientColorIDParameter = new SqlParameter(@"ClientColorID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter clientIDParameter = new SqlParameter(@"ClientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter templateIDParameter = new SqlParameter(@"TemplateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
        internal CreateClientwelcomeDBCommand() : base ("[dbo].[PortalWelcome]")
            {
            SetParameters(
                        template_ClientIDParameter,
                        clientColorIDParameter,
                        clientIDParameter,
                        templateIDParameter

                         );

        }
        internal void SetOutPutParameters(
                                         out int Id,
                                         out int Ids
                                         )
        {
            Id = (int)templateIDParameter.Value;
            Ids = (int)clientColorIDParameter.Value;
        }
        internal void SetInputParameters(
                                        int ClientID,
                                        int templateID
                                        )
        {
            clientIDParameter.Value = ClientID;
            templateIDParameter.Value = templateID;
        }
    }
}
