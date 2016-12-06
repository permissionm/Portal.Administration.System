using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Portal.AdminSystem.DataAccess
{
    public class CreateSubjectWelcomeDBCommand : DatabaseCommand
    {
        private readonly SqlParameter templateIDParameter = new SqlParameter(@"TemplateID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null);
        private readonly SqlParameter subjectParameter = new SqlParameter(@"Subject", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, null);
     internal CreateSubjectWelcomeDBCommand() : base ("[dbo].[PortalWelcomeSubject]")
            {
            SetParameters(
                        templateIDParameter,
                        subjectParameter

                         );

        }
        internal void SetOutPutParameters(
                                         out int Id
                                         )
        {
            Id = (int)templateIDParameter.Value;

        }
        internal void SetInputParameters(
                                        string subject
                                        )
        {
            subjectParameter.Value = subject;
        }
    }
}
