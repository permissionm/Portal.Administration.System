using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
    public class IcasConnect
    {
        public int MenuPDFID{ get; set; }
        public int ID { get; set; }
        [Display(Name = "Client ListID")]
        public int ClientListID { get; set; }
        [Required]
        [Display(Name = "Client")]
        public int ClientID { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Display(Name = "PDF Name")]
        public string PDFName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
       
    }

    public class IcasConnectView : IcasConnect
    {
        public SelectList ClientList { get; set; }
    }

    public class IcasConnectSearch
    {
        [Display(Name = "Client Name")]
        public string SearchClientname { get; set; }
        [Display(Name = "PDF Name")]
        public string SearchPDFName { get; set; }
        [Display(Name = "ClientID")]
        public string SearchClientID { get; set; }
        public List<IcasConnect> IcasConnectResults { get; set; } = new List<IcasConnect>();
    }
}
