using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
   public class ExecClientUsergroups
    {   
        [Display(Name = "UsergroupID")]
        public int UsergroupID { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Trial Period")]
        public int TrialPeriod { get; set; }

        [Display(Name = "Principal")]
        public bool Principal { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Priority")]
        public int Priority { get; set; }

        [Display(Name = "Grouping")]
        public int Grouping { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

    }

    public class SearchExecClient
    {
        [Display(Name = "Client Name")]
        public string SearchDescription { get; set; }

        public List<ExecClientUsergroups> ExecClientUsergroupResults { get; set; } = new List<ExecClientUsergroups>();
    }
}
