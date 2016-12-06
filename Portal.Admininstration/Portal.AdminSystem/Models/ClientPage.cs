using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
    public class ClientPage
    {
        [Display(Name = "SettingID")]
        public int ClientSettingID { get; set; }

        [Display(Name = "TemplateID")]
        public int PageTemplateType_LinkID { get; set; }

        [Display(Name = "ClientID")]
        public int ClientID { get; set; }
        public string Clientname { get; set; }
    }

    public class SearchPage
    {

        [Display(Name = "Client Name")]
        public string SearchClientName { get; set; }

        public List<ClientPage> PageResults { get; set; } = new List<ClientPage>();
    }
}
