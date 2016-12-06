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
    public class UsergroupsController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        UsergroupLogic usergroupLogic = new UsergroupLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.RetrieveUsergroups());
        }

        public ActionResult Details(int id)
        {
            return View(usergroupLogic.Find(id));
        }

        public ActionResult Create()
        {
           UsergroupsModelView usergroupsModelView = new UsergroupsModelView();
            usergroupsModelView.ClientList = new SelectList(businessLogic.PortalClientLists(0), "ClientID","ClientName");
            return View(usergroupsModelView);
        }

        [HttpPost]
        public ActionResult Create(UsergroupsModel usergroupsModel)
        {
            try
            {
                businessLogic.CreateUsergroups(usergroupsModel);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(usergroupLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, UsergroupsModel usergroupsModel)
        {
            try
            {
                usergroupLogic.UpdateUsergroup(usergroupsModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        } 

        public ActionResult Delete(int id)
        {
            return View(usergroupLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                usergroupLogic.Delete(id);
                ViewBag.AlertMsg = "Usergroup deleted successfully";
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SearchUsergroup()
        {
            UsergroupSearch usergroupSearch = new Models.UsergroupSearch();
            usergroupSearch.UsergroupResults = new List<UsergroupsModel>();
            return View(usergroupSearch);
        }

        [HttpPost]
        public ActionResult SearchUsergroup(UsergroupSearch usergroupSearch)
        {
            usergroupSearch.UsergroupResults = businessLogic.RetrieveUsergroupResult(usergroupSearch).ToList();
            return View(usergroupSearch);
        }
    }
}
