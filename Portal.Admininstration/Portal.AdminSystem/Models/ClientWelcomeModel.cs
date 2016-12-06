using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
  public class ClientWelcomeModel
    {
        [Display (Name ="WelcomeID")]
        public int Template_ClientID { get; set; }

        [Required]
        [Display (Name ="Template")]
        public int TemplateID { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [Display(Name ="ColorID")]
        public int ClientColorID { get; set; }

        [Display(Name ="Color")]
        public string Color { get; set; }
        public string Clientname { get; set; }
        public string Subject { get; set; }
     
    }
    public class ClientViewWelcome : ClientWelcomeModel
    {
        public SelectList ClientList { get; set; }
        public SelectList TemplateList { get; set; }
    }

    public class SearchWelcome
    {
        [Display(Name ="Client Name")]
        public  string SearchClientname { get; set; }

        public List<ClientWelcomeModel> WelcomeResults { get; set; } = new List<ClientWelcomeModel>();
        
    }
}
