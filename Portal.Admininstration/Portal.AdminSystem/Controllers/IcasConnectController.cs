using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Portal.AdminSystem.Models;
using System.Configuration;

namespace Portal.AdminSystem.Controllers
{
    [Authorize]
    public class IcasConnectController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["ContentConnection"].ConnectionString;
        IcasConnectLogic icasConnectLogic = new IcasConnectLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.PortalRetrieveIcasConnect());
        }

        public ActionResult Create()
        {
            IcasConnectView icasConnectView = new IcasConnectView();
            icasConnectView.ClientList = new SelectList(businessLogic.PortalIcasConnect(0), "ClientID", "ClientName");
            return View(icasConnectView);
        }

        [HttpPost]
        public ActionResult Create(IcasConnect icasConnect)
        {
            try
            {
                businessLogic.PortalAboutIcasConnect(icasConnect);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchIcasConnect()
        {
            IcasConnectSearch icasConnectSearch = new Models.IcasConnectSearch();
            icasConnectSearch.IcasConnectResults = new List<IcasConnect>();
            return View(icasConnectSearch);
        }

        [HttpPost]
        public ActionResult SearchIcasConnect(IcasConnectSearch icasConnectSearch)
        {
           icasConnectSearch.IcasConnectResults = businessLogic.RetrieveIcasConnectResult(icasConnectSearch).ToList();
            return View(icasConnectSearch);
        }

        public ActionResult Details(int id)
        {
            return View(icasConnectLogic.Find(id));
        }
    }
}
