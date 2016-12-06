using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
    public class ClientModel
    {
        public int ClientID { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Client Mail Alias")]
        public string ClientMailAlias { get; set; }

        [Display(Name = "Client Mail From")]
        public string ClientMailFromAddr { get; set; }

        [Display(Name = "Help URL")]
        public string HelpURL { get; set; }

        [Display(Name = "Site type")]
        public int SiteType { get; set; }

        [Required]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Display(Name = "Use CDN")]
        public bool UseCDN { get; set; }

        [Display(Name = "Welcome Subject")]
        public string WelcomeSubject { get; set; }
    }

    public class ClientSearch
    {
        [Display(Name = "Client Name")]
        public string SearchClientName { get; set; }

        [Display(Name = "Display Name")]
        public string SearchDisplayName { get; set; }


        [Display(Name = "ClientID")]
        public string SearchClientID { get; set; }
        public List<ClientModel> ClientResults { get; set; } = new List<ClientModel>();
    }
}
