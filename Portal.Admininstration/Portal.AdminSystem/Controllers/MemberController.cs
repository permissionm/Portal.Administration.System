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
    public class MemberController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MemberLogic memberLogic = new MemberLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult MemberSearch()
        {
            MemberSearch memberSearch = new Models.MemberSearch();
            memberSearch.MemberSearchResults = new List<MemberModel>();
            return View(memberSearch);
        }

        [HttpPost]
        public ActionResult MemberSearch(MemberSearch memberSearch)
        {
            memberSearch.MemberSearchResults = businessLogic.RetrieveSearchMemberResult(memberSearch).ToList();
            return View(memberSearch);
        }

        public ActionResult Index()
        {
            return View(businessLogic.PortalRetrieveMembers());
        }

        public ActionResult Details(int id)
        {
            return View(memberLogic.Find(id));
        }

        public ActionResult Create()
        {
            MemberViewModel memberViewModel = new MemberViewModel();
            memberViewModel.UsergroupList = new SelectList(businessLogic.PortalMemberUsergroupList(0), "UsergroupID", "Description");
            memberViewModel.ClientList = new SelectList(businessLogic.PortalMemberClientList(0), "ClientID", "ClientName");
            return View(memberViewModel);
        }

        [HttpPost]
        public ActionResult Create(MemberModel memberModel)
        {
            try
            {
                businessLogic.PortalCreateMember(memberModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(memberLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(string id, MemberModel memberModel)
        {
            try
            {
                memberLogic.UpdateMember(memberModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GetUsergroupByClientId(int? clientId)
        {
            var userGroups = businessLogic.RetrieveUsergroupResult(new UsergroupSearch
            {
                ClientId = clientId
            });

            return Json(userGroups);
        }
    }
}
