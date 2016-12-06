using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.AdminSystem.Models;
using System.Configuration;
using Portal.AdminSystem.Shared;

namespace Portal.AdminSystem.Controllers
{
    public class ClientController : BaseController
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        ClientLogic clientLogic = new ClientLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.PortalRetrieveClient());
        }

        public ActionResult Details(int id)
        {
            return View(clientLogic.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientModel clientModel)
        {       
            string username = LoggedOnUserName;
            try
            {
                if (ModelState.IsValid)
                {
                    businessLogic.PortalCreateClient(clientModel);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(clientLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ClientModel clientModel)
        {
            try
            {
                clientLogic.UpdateClient(clientModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(clientLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (clientLogic.Delete(id))
                {
                    ViewBag.AlertMsg = "Client Deleted";
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult ClientSearch()
        {
            ClientSearch clientSearch = new Models.ClientSearch();
            clientSearch.ClientResults = new List<ClientModel>();
            return View(clientSearch);
        }

        [HttpPost]
        public ActionResult ClientSearch(ClientSearch clientSearch)
        {
            clientSearch.ClientResults = businessLogic.RetrieveClientResult(clientSearch).ToList();
            return View(clientSearch);
        }
    }
}