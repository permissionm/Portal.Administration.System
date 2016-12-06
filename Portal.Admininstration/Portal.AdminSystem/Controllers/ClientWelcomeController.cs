using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.AdminSystem.Models;
using System.Configuration;

namespace Portal.AdminSystem.Controllers
{
    [Authorize]
    public class ClientWelcomeController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        ClientWelcomeLogic clientWelcomeLogic = new ClientWelcomeLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Welcomes()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(clientWelcomeLogic.Find(id));
        }
        
        public ActionResult Welcome()
        {
            ClientViewWelcome clientViewWelcome = new ClientViewWelcome();
            clientViewWelcome.ClientList = new SelectList(businessLogic.PortalPageClientLists(0), "ClientID", "ClientName");
            clientViewWelcome.TemplateList = new SelectList(businessLogic.PortalTemplatesList(25), "TemplateID", "Subject");
            return View(clientViewWelcome);
        }

        [HttpPost]
        public ActionResult Welcome(ClientWelcomeModel clientWelcomeModel)
        {
            try
            {
                businessLogic.CreateClientWelcome(clientWelcomeModel);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Update(int id)
        {
            return View(clientWelcomeLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Update(int id, ClientWelcomeModel clientWelcomeModel)
        {
            try
            {
                clientWelcomeLogic.UpdateWelcome(clientWelcomeModel);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchClient()
        {
            SearchWelcome searchWelcome = new Models.SearchWelcome();
            searchWelcome.WelcomeResults = new List<ClientWelcomeModel>();
            return View(searchWelcome);
        }

        [HttpPost]
        public ActionResult SearchClient(SearchWelcome searchWelcome)
        {
            searchWelcome.WelcomeResults = businessLogic.ClientWelcomeResults(searchWelcome).ToList();
            return View(searchWelcome);
        }

    }
}

