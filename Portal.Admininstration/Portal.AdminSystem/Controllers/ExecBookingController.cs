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
    public class ExecBookingController : Controller
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["ExecCareConnection"].ConnectionString;
        ExecBookingLogic execBookingLogic = new ExecBookingLogic(connectionString);
        BusinessLogic businessLogic = new BusinessLogic();

        public ActionResult Index()
        {
            return View(businessLogic.ExecCareRetrieveCalender());
        }

        public ActionResult Details(int id)
        {
            return View(execBookingLogic.Find(id));
        }

        public ActionResult UpdateBooking(int id)
        {
            return View(execBookingLogic.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateBooking(int id, ExecBookingModel execBookingModel)
        {
            try
            {
                execBookingLogic.UpdateBooking(execBookingModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BookingSearch()
        {     
            SearchBooking bookingSearch = new Models.SearchBooking();
            bookingSearch.BookingResults = new List<ExecBookingModel>();
            return View(bookingSearch);
        }

        [HttpPost]
        public ActionResult BookingSearch(SearchBooking searchBooking)
        {
            searchBooking.BookingResults = businessLogic.RetriveBookingResults(searchBooking).ToList();
            return View(searchBooking);
        }

        public ActionResult Edit(int id)
        {
            return View(execBookingLogic.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ExecBookingModel execBookingModel)
        {
            try
            {
                execBookingLogic.UpdateBooking(execBookingModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
