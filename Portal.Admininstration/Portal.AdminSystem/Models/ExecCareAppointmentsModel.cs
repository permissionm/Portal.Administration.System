using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
   public class ExecCareAppointmentsModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "PackageID")]
        public int PackageID { get; set; }

        [Display(Name = "TypeID")]
        public int TypeID { get; set; }

        [Display(Name = "Minutes")]
        public int MinutesOfAppointment { get; set; }
    }
}
