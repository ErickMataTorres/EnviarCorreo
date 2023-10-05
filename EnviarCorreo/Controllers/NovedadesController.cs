using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnviarCorreo.Controllers
{
    public class NovedadesController : Controller
    {
        // GET: Novedades
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Novedades()
        {
            return View();
        }
    }
}