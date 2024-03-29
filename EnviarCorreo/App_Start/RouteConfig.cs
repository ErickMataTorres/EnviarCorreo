﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace EnviarCorreo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        //public static void Saldo(HttpConfiguration config)
        //{
        //    //web api configuracion y servicio
        //    config.EnableCors();

        //    //web apo routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute
        //        (
        //            name:"DefaultApi",
        //            routeTemplate:"api/{controller}/{id}",
        //            defaults: new {id=RouteParameter.Optional}
        //        );
        //}
    }
}
