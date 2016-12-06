using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem
{
   public class IcasConnectLogic : DatabaseLogic
    {
        public IcasConnectLogic(string connectionString) : base(connectionString)
        {

        }

        public IcasConnect Find(int? MenuPDFID)
        {
            string query = "Select MenuPDFID, ClientListID, ClientID, ClientName, PDFID, PDFName,Description FROM tblMenuPDF where MenuPDFID =" + MenuPDFID + "";
            return this.db.Query<IcasConnect>(query).SingleOrDefault();
        }
    }
}


