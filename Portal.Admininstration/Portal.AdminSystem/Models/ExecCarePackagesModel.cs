using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
    public class ExecCarePackagesModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Stream")]
        public int Stream { get; set; }
        [Display(Name = "Active")]
        public bool Active { get; set; }
    }

    public class ExecCarePackagesViewModel : ExecCarePackagesModel
    {
        public SelectList StreamList { get; set; }

    }
    public class SearchExecPackage
    {
        [Display(Name = "Description")]
        public string SearchDescription { get; set; }
        public List<ExecCarePackagesModel> PackageResults { get; set; } = new List<ExecCarePackagesModel>();
    }
}
