using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Portal.AdminSystem.Controllers
{
    [Authorize]
   public class BaseController : Controller
    {

        public BaseController()
        {
            this.LoggedOnUserName = "test";
        }

     
        protected string LoggedOnUserName { get; set; }
    }
}
