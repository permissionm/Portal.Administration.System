using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem.Controllers
{
    [Authorize]
    public class WelcomeSubjectController : Controller
    {
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult SubjectWelcome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubjectWelcome(WelcomeSubjectModel welcomeSubjectModel)
        {
            try
            {

                businessLogic.CreateSubjectWelcome(welcomeSubjectModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchSubject()
        {
            SearchWelcomeSubject searchWelcomeSubject = new Models.SearchWelcomeSubject();
            searchWelcomeSubject.SubjectResults = new List<WelcomeSubjectModel>();
            return View(searchWelcomeSubject);
        }

        [HttpPost]
        public ActionResult SearchSubject(SearchWelcomeSubject searchWelcomeSubject)
        {
            searchWelcomeSubject.SubjectResults = businessLogic.SubjectResults(searchWelcomeSubject).ToList();
            return View(searchWelcomeSubject);
        }

    }

}