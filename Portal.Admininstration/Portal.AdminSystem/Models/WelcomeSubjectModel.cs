using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
   public class WelcomeSubjectModel
    {
        public int TemplateID { get; set; }

        [Required]
        [Display(Name = "Welcome Subject")]
        public string Subject { get; set; }

        public DateTime DateCreate { get; set; }
    }

    public class SearchWelcomeSubject
    {
        [Display(Name = "Welcome Subject")]
        public string SearchSubject { get; set; }

        public List<WelcomeSubjectModel> SubjectResults { get; set; } = new List<WelcomeSubjectModel>();
    }

}
