using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
    public class ExecUsersModel
    {
        [Display(Name = "UserID")]
        public int ExecUserID { get; set; }

        [Display(Name = "Name")]
        public string ExecName { get; set; }

        [Display(Name = "Surname")]
        public string ExecSurname { get; set; }

        [Display(Name = "Email")]
        public string ExecEmail { get; set; }

        [Display(Name = "Password")]
        public string ExecPassword { get; set; }

        [Display(Name = "TypeID")]
        public int TypeID { get; set; }
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Region")]
        public int ExecRegionID { get; set; }
        public string TypeText { get; set; }
        public string RegionDescription { get; set; }

        [Display(Name = "Username")]
        public string ExecUsername { get; set; }
      
        [Display(Name = "Default")]
        public bool IsDefault { get; set; }
    }

    public class ExecUsersViewModel : ExecUsersModel
    {
        public SelectList TypeList { get; set; }
        public SelectList RegionList { get; set; }
    }

    public class SearchExecUsers
    {
        [Display(Name = "Name")]
         public string SearchName { get; set; }
         [Display(Name = "Surname")]
         public string SearchSurname { get; set; }
         [Display(Name = "Email")]
         public string SearchEmail { get; set; }
         public List<ExecUsersModel> ExecUsersResults { get; set; } = new List<ExecUsersModel>();
    }
}

