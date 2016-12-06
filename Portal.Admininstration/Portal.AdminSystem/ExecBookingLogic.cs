using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
   public class ExecBookingLogic : DatabaseLogic
    {
        public ExecBookingLogic(string connectionString) : base(connectionString)
        {

        }

        public ExecBookingModel Find(int? ID)
        {
            string query = "Select * From ExecCareCalander where ID =" + ID + "";
            return this.db.Query<ExecBookingModel>(query).SingleOrDefault();
        }

        public void UpdateBooking(ExecBookingModel execBookingModel)
        {
            try
            {
                db.Open();
                db.Execute("PortalExecUpdateBooking", execBookingModel, commandType: CommandType.StoredProcedure);
                db.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
