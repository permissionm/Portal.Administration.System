using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
   public class MemberModel
    {
        [Display(Name = "MemberID")]
        public int MemberID { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
       
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }


        [Display(Name = "Welcome Sent")]
        public bool WlcSent { get; set; }

        [Required]
        [Display(Name = "Usergroup")]
        public int UsergroupID { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public class MemberViewModel : MemberModel
    {
        public SelectList UsergroupList { get; set; }
        public SelectList ClientList { get; set; }
    }

    public class MemberSearch
    {
        [Display(Name = "Email")]
        public string SearchEmail { get; set; }
        [Display(Name = "Name")]
        public string SearchName { get; set; }
        [Display(Name = "Surname")]
        public string SearchSurname { get; set; }
        public List<MemberModel> MemberSearchResults { get; set; } = new List<MemberModel>();
    }
}
