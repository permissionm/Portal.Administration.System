using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Portal.AdminSystem.Models;

namespace Portal.AdminSystem.Controllers
{
    [Authorize]
    public class PortalUploadsController : Controller
    {
        public ActionResult GlobalQuiz()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GlobalQuiz(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\GlobalQuiz", fileName);
                    file.SaveAs(path);

                    var globalQuiz = @"C:\inetpub\wwwroot\GlobalQuizZA\css";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;

                    fastZip.ExtractZip(path, globalQuiz, fileFilter);
                }
            }
            return RedirectToAction("PollCMS");
        }

        public ActionResult PollCMS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PollCMS(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\PollCMS", fileName);
                    file.SaveAs(path);

                    var pollCMS = @"C:\inetpub\wwwroot\PollsCMS\Resources";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;

                    fastZip.ExtractZip(path, pollCMS, fileFilter);
                }
            }
            return RedirectToAction("Calculator");
        }

        public ActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculator(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\HealthCalculators", fileName);
                    file.SaveAs(path);

                    var healthCalculators = @"C:\inetpub\wwwroot\HealthCalculatorsZA\Assets\Css";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;

                    fastZip.ExtractZip(path, healthCalculators, fileFilter);
                }
            }
            return RedirectToAction("Headers");
        }

        public ActionResult Headers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Headers(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\Headers", fileName);
                    file.SaveAs(path);

                    var headers = @"C:\inetpub\wwwroot\GlobalPortal\Views\Shared\Headers";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;

                    fastZip.ExtractZip(path, headers, fileFilter);
                }
            }
            return RedirectToAction("Banner");
        }
        public ActionResult Banner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Banner(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\Banners", fileName);
                    file.SaveAs(path);

                    var banners = @"C:\inetpub\wwwroot\GlobalPortal\Views\Shared\Banners";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;

                    fastZip.ExtractZip(path, banners, fileFilter);
                }
            }
            return RedirectToAction("Footers");
        }
        public ActionResult Footers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Footers(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\Footers", fileName);
                    file.SaveAs(path);

                    var footers = @"C:\inetpub\wwwroot\GlobalPortal\Views\Shared\Footers";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;

                    fastZip.ExtractZip(path, footers, fileFilter);
                }
            }
            return RedirectToAction("Menus");
        }

        public ActionResult Menus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Menus(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\Menus", fileName);
                    file.SaveAs(path);

                    var menus = @"C:\inetpub\wwwroot\GlobalPortal\Views\Shared\Menus";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;

                    fastZip.ExtractZip(path, menus, fileFilter);
                }
            }
            return RedirectToAction("Summary");
        }

        public ActionResult Summary()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Summary(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\PointOfSummary", fileName);
                    file.SaveAs(path);

                    var pointOfSummary = @"C:\inetpub\wwwroot\GlobalPortal\Views\Shared\PointsSummary";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;

                    fastZip.ExtractZip(path, pointOfSummary, fileFilter);
                }
            }

            return RedirectToAction("EcareImages");
        }


        public ActionResult EcareImages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EcareImages(PortalUploads portal)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(@"C:\Dropbox\ecareimages\PortalAdminTest\DropboxImg", fileName);   
                    file.SaveAs(path);

                    var ecareImages = @"C:\Dropbox\ecareimages";
                    FastZip fastZip = new FastZip();
                    string fileFilter = null;
                    
                    fastZip.ExtractZip(path, ecareImages, fileFilter);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
