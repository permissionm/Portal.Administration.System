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
    public class ExecMemberRegisterController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["ExecCareConnection"].ConnectionString;
        ExecMemberRegisterLogic execMemberRegisterLogic = new ExecMemberRegisterLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.PortalRetrieveExecMembers());
        }

        public ActionResult Details(int id)
        {
            return View(execMemberRegisterLogic.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(execMemberRegisterLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ExecMemberRegisterModel execMemberRegisterModel)
        {
            try
            {
                execMemberRegisterLogic.UpdateMember(execMemberRegisterModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ExecMemberSearch()
        {
            ExecMemberSearch execMemberSearch = new Models.ExecMemberSearch();
            execMemberSearch.ExecMemberResults = new List<ExecMemberRegisterModel>();
            return View(execMemberSearch);
        }

        [HttpPost]
        public ActionResult ExecMemberSearch(ExecMemberSearch execMemberSearch)
        {
            execMemberSearch.ExecMemberResults = businessLogic.RetrieveExecCareMemberResult(execMemberSearch).ToList();
            return View(execMemberSearch);
        }
    }
}
