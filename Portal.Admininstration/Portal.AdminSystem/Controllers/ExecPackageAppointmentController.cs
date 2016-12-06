using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem.Controllers
{
    [Authorize]
    public class ExecPackageAppointmentController : Controller
    {
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.RetrieveAppointment());
        }

        public ActionResult PackageAppointment()
        {
            ExecPackageAppointment execPackagesAppointmentModel = new ExecPackageAppointment();
            execPackagesAppointmentModel.TypeList = new SelectList(businessLogic.ExecAppointmentTypesList(0), "TypeID", "TypeText");
            execPackagesAppointmentModel.PackageList = new SelectList(businessLogic.ExecSelectPackage(-1), "ID", "Description");
            return View(execPackagesAppointmentModel);
        }

        [HttpPost]
        public ActionResult PackageAppointment(ExecPackageAppointment execPackageAppointment)
        {
            try
            {
                businessLogic.CreateAppointMent(execPackageAppointment);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
