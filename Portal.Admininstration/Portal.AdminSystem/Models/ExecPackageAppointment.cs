using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
    public class ExecPackageAppointment
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "PackageID")]
        public int PackageID{ get; set; }
        [Display(Name = "TypeID")]
        public int TypeID { get; set; }
        [Display(Name = "Minutes")]
        public int MinutesOfAppointment { get; set; }
        public SelectList TypeList { get; set; }
        [Display(Name = "Type")]
        public string TypeText { get; set; }
        [Display(Name = "Package")]
        public string Description { get; set; }
        public SelectList PackageList { get; set; }
        [Display(Name = "zOrder")]
        public int zOrder { get; set; }
    }
}
