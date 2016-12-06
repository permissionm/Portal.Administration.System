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
    public class ExecCarePackagesController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["ExecCareConnection"].ConnectionString;
        ExecCarePackagesLogic execCarePackagesLogic = new ExecCarePackagesLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.PortalRetrieveExecPackages());
        }

        public ActionResult Details(int id)
        {
            return View(execCarePackagesLogic.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Package()
        {
           ExecCarePackagesViewModel execCarePackagesViewModel = new ExecCarePackagesViewModel();
           execCarePackagesViewModel.StreamList = new SelectList(businessLogic.PortalStreamList(0), "Stream", "Stream");
            return View(execCarePackagesViewModel);   
        }

        [HttpPost]
        public ActionResult Package(ExecCarePackagesModel execCarePackagesModel)
        {
            try
            {
                businessLogic.CreateExecPackage(execCarePackagesModel);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(execCarePackagesLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ExecCarePackagesModel execCarePackagesModel)
        {
            try
            {
                execCarePackagesLogic.UpdateExecPackage(execCarePackagesModel);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(execCarePackagesLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (execCarePackagesLogic.Delete(id))
                {
                    ViewBag.AlertMsg = "Package Deleted";
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SearchPackages()
        {
            SearchExecPackage searchExecPackage = new Models.SearchExecPackage();
            searchExecPackage.PackageResults = new List<ExecCarePackagesModel>();
            return View(searchExecPackage);
        }

        [HttpPost]
        public ActionResult SearchPackages(SearchExecPackage searchExecPackage)
        {
            searchExecPackage.PackageResults = businessLogic.RetrievePackageResult(searchExecPackage).ToList();
            return View(searchExecPackage);
        }
    }
}
