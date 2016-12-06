using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.AdminSystem.Models;
using System.Configuration;

namespace Portal.AdminSystem.Controllers
{
    public class ClientPageController : BaseController
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        PageLogic pageLogic = new PageLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(pageLogic.Find(id));
        }

        public ActionResult Edit(int id)
        {
            return View(pageLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ClientPage clientpage)
        {
            try
            {
                pageLogic.UpdateClientPage(clientpage);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchPage()
        {
            SearchPage searchpage = new Models.SearchPage();
            searchpage.PageResults = new List<ClientPage>();
            return View(searchpage);
        }

        [HttpPost]
        public ActionResult SearchPage(SearchPage searchPage)
        {
            searchPage.PageResults = businessLogic.ClientPageResults(searchPage).ToList();
            return View(searchPage);
        }

    }
}
