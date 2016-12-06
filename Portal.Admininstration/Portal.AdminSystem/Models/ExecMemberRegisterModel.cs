using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
  public class ExecMemberRegisterModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int MemberID { get; set; }
        public int StatusID { get; set; }
        public int ExecPackageID { get; set; }
        public DateTime EntryDate { get; set; }
        public int ExecRegionID { get; set; }
        public string CostCenterNumber { get; set; }
        public string BranchCode { get; set; }
        public string EmployeeNumber { get; set; }
        public int ClientID { get; set; }

        public string Description { get; set; }

    }
    public class ExecMemberSearch
    {
        [Display(Name = "Name")]
        public string SearchName { get; set; }

        [Display(Name = "Surname")]
        public string SearchSurname { get; set; }
        public List<ExecMemberRegisterModel> ExecMemberResults { get; set; } = new List<ExecMemberRegisterModel>();
    }
}
