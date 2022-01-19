using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Village_project_teast_19._1._21.Controllers
{
    public class ChifController : Controller
    {
        // GET: Chif
        public ActionResult DisplayChif()
        {
            ViewBag.Title = "Welcome Chif";
            return View();
        }
    }
}