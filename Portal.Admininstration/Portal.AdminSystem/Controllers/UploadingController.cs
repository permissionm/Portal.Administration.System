using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.AdminSystem.Controllers
{
    public class UploadingController : Controller
    {
        // GET: Uploading
        public ActionResult Index()
        {
            return View();
        }

        // GET: Uploading/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Uploading/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uploading/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uploading/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Uploading/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uploading/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Uploading/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
