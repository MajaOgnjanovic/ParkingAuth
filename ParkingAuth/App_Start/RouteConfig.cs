using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ParkingAuth
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            /* ########## Front End ########## */
            //slug ruta
            routes.MapRoute(
                name: "slug", url: "slug/id",
                defaults: new { controller = "Front", action = "slug", id = UrlParameter.Optional }   //slug ruta
            );
            //end slug ruta 
            //.......................................................................................................
            //pages ruta
            routes.MapRoute(
               name: "pages", url: "pages/{action}/id",
               defaults: new { controller = "Front", action = "pages", id = UrlParameter.Optional }  //pages ruta
           );
            //end pages ruta
            //.......................................................................................................
            routes.MapRoute(
                "home",
                "home/{index}",
                  new
                  {
                      Controller = "Front",
                      action = "Index",
                      id = UrlParameter.Optional
                  });

            routes.MapRoute(
               "blog",
               "{blog}",
                 new
                 {
                     Controller = "Front",
                     action = "Blog",
                     id = UrlParameter.Optional
                 });

            routes.MapRoute(
               "kontakt",
               "{kontakt}",
                 new
                 {
                     Controller = "Front",
                     action = "Kontakt",
                     id = UrlParameter.Optional
                 });
            routes.MapRoute(
               "o_nama",
               "{o_nama}",
                 new
                 {
                     Controller = "Front",
                     action = "ONama",
                     id = UrlParameter.Optional
                 });
            /* ########## Front End ########## */


            /* ########## Back End ########## */
            routes.MapRoute(
               "admin/back-meni",
               "admin/{controller}/{action}/{id}",
                 new
                 {
                     Controller = "BackMeni",        /*Back Meni*/
                     action = "Index",
                     id = UrlParameter.Optional
                 });

            routes.MapRoute(
                "admin/nacin-placanja",
                "admin/{controller}/{action}/{id}",
                  new
                  {
                      Controller = "NacinPlacanja",        /*NACIN PLACANJA*/
                      action = "Index",
                      id = UrlParameter.Optional
                  });

            routes.MapRoute(
                 "admin/parking-zone",
                 "admin/{controller}/{action}/{id}",
                   new
                   {
                       Controller = "ParkingZone",        /*PARKING ZONE*/
                       action = "Index",
                       id = UrlParameter.Optional
                   });

            routes.MapRoute(
                 "admin/vrsta-korisnici",
                 "admin/{controller}/{action}/{id}",
                 new
                 {
                     Controller = "VrstaKorisnici",       /*VRSTA KORISNICI*/
                     action = "Index",
                     id = UrlParameter.Optional
                 });


            routes.MapRoute(
                  "admin/korisnici",
                  "admin/{controller}/{action}/{id}",
                new
                {
                    Controller = "Korisnici",            /*KORISNICI*/
                    action = "Index",
                    id = UrlParameter.Optional
                });


            routes.MapRoute(
                   "admin/parking-karte",
                   "admin/{controller}/{action}/{id}",
                 new
                 {
                     Controller = "ParkingKarte",       /*PARKING KARTE*/
                     action = "Index",
                     id = UrlParameter.Optional
                 });



            routes.MapRoute(
                    "admin",
                    "admin/{controller}/{action}/{id}",
                    new
                    {
                        Controller = "Back",              /*BACK*/
                        action = "Index",
                        id = UrlParameter.Optional
                    });

            /* ########## Back End ########## */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Back", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
    
