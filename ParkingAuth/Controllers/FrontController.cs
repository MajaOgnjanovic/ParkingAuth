using ParkingAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ParkingAuth.Controllers
{
    public class FrontController : Controller
    {

        private ParkingServisPajaASPEntities db = new ParkingServisPajaASPEntities();
        // GET: Front
        public ActionResult Index()
        {
            return View("~/Views/front-end/index.cshtml");
        }

       



        //ovo sam dodala
        public ActionResult Pages(long? id)
        {
            menu data = db.menu
                .Where(x => x.menu_id == id)
                .FirstOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ovo je za gresku 404
            if (data == null)
            {
                //var response_code = HttpNotFound();
                var response_code = HttpStatusCode.NotFound;
                //Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("~/Views/front-end/response/_404.cshtml",
                    response_code);
            }

            return View("~/Views/front-end/pages.cshtml", data);
        }
        public ActionResult slug(string id)
        {
            var input = Server.HtmlEncode(id);
            menu data = db.menu
            .Where(x => x.slug == id)
            .FirstOrDefault();
            //return Json(new { par = data }, JsonRequestBehavior.AllowGet); ;
            return View("~/Views/front-end/pages.cshtml", data);
        }

    }
}



