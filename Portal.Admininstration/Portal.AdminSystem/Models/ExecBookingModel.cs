using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Portal.AdminSystem.Models
{
  public class ExecBookingModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Start DateTime")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End DateTime")]
        public DateTime EndDateTime { get; set; }

        [Display(Name = "Label")]
        public int  Label { get; set; }

        [Display(Name = "ResourceID")]
        public int ResourceID { get; set; }

        [Display(Name = "MemberID" )]
        public string MemberID { get; set; }
        public bool Deleted { get; set; }
        public bool  AllDay { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ReminderInfo { get; set; }
        public int Status { get; set; }
        public int TypeID { get; set; }
        public int UserID { get; set; }
    }

    public class SearchBooking
    {
        [Display(Name = "Subject")]
        public string SearchSubject { get; set; }

        [Display(Name = "MemberID")]
        public string SearchMemberID { get; set; }
        public List<ExecBookingModel> BookingResults { get; set; } = new List<ExecBookingModel>();
    }
}
