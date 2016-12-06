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
    public class ExecClientUsergroupsController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["ExecCareConnection"].ConnectionString;
        ExecClientUsergroupsLogic execClientUsergroupsLogic = new ExecClientUsergroupsLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.PortalRetrieveExecClientUsergrops());
        }

        public ActionResult Details(int id)
        {
            return View(execClientUsergroupsLogic.Find(id));
        }

        public ActionResult ExecClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExecClient(ExecClientUsergroups execClientUsergroups)
        {
            try
            {
                businessLogic.CreateExecClientUsergroups(execClientUsergroups);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(execClientUsergroupsLogic.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, ExecClientUsergroups execClientUsergroups)
        {
            try
            {
                execClientUsergroupsLogic.UpdateExecUsergroup(execClientUsergroups);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchExecClientUsergroup()
        {
            SearchExecClient searchExecClient = new Models.SearchExecClient();
            searchExecClient.ExecClientUsergroupResults = new List<ExecClientUsergroups>();
            return View(searchExecClient);
        }

        [HttpPost]
        public ActionResult SearchExecClientUsergroup(SearchExecClient searchExecClient)
        {
            searchExecClient.ExecClientUsergroupResults = businessLogic.RetrieveExecClientUsergroupResults(searchExecClient).ToList();
            return View(searchExecClient);
        }
    }
}
