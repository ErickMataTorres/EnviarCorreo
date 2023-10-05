using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnviarCorreo.Controllers
{
    public class PromocionesController : Controller
    {
        // GET: Promociones
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Promociones()
        {
            return View();
        }
    }
}