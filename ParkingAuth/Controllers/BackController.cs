using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingAuth.Controllers
{
    public class BackController : Controller
    {
        // GET: Back
        public ActionResult Index()
        {
            return View("~/Views/back-end/index.cshtml");
        }
    }
}