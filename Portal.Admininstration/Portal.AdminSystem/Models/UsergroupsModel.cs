using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
    public class UsergroupsModel
    {
        public int ID { get; set; }
        public int UsergroupID { get; set; }

        [Display(Name = "Group Description")]
        public string GroupDescription { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Priority")]
        public int Priority { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
     
        [Display(Name = "UsergroupUsageID")]
        public int UsergroupUsageID { get; set; }

        [Display(Name = "Reporting Level")]
        public int ReportingLevel { get; set; }

        [Display(Name = "ParentID")]
        public int ParentID { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "LookUpValueID")]
        public int LookupValueID { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int Template_ClientID { get; set; }
      
    }
    public class UsergroupsModelView : UsergroupsModel
    {
        public SelectList ClientList { get; set; }
      
    }
    public class UsergroupSearch
    {
        [Display(Name = "Description")]
        public string SearchDescription { get; set; }
        public List<UsergroupsModel> UsergroupResults { get; set; } = new List<UsergroupsModel>();

        public int? ClientId { get; set; }
    }
}
