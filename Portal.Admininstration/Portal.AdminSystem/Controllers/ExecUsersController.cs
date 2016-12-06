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
    public class ExecUsersController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["ExecCareConnection"].ConnectionString;
        ExecUsersLogic execUsersLogic = new ExecUsersLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.RetrieveExecUsers());
        }

        public ActionResult Details(int id)
        {
            return View(execUsersLogic.Find(id));
        }

        public ActionResult ExecUsers()
        {
            ExecUsersViewModel execUsersModel = new ExecUsersViewModel();
            execUsersModel.TypeList = new SelectList(businessLogic.ExecCareUserTypesLists(0), "TypeID", "TypeText");
            execUsersModel.RegionList = new SelectList(businessLogic.ExecCareUserRegionLists(0), "ExecRegionID", "RegionDescription");
            return View(execUsersModel);
        }

        [HttpPost]
        public ActionResult ExecUsers(ExecUsersModel execUsersModel)
        {
            try
            {
                businessLogic.CreateExecUserLogin(execUsersModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(execUsersLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ExecUsersModel execUsersModel)
        {
            try
            {
                execUsersLogic.UpdateExecUsers(execUsersModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchExecUsers()
        {
            SearchExecUsers searchExecUsers = new Models.SearchExecUsers();
            searchExecUsers.ExecUsersResults = new List<ExecUsersModel>();
            return View(searchExecUsers);
        }

        [HttpPost]
        public ActionResult SearchExecUsers(SearchExecUsers searchExecUsers)
        {
            searchExecUsers.ExecUsersResults = businessLogic.RetrieveSearchExecResult(searchExecUsers).ToList();
            return View(searchExecUsers);
        }
    }
}
