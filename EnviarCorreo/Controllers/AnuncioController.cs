using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirebirdSql.Data.FirebirdClient;

namespace EnviarCorreo.Controllers
{
    public class AnuncioController : Controller
    {
        // GET: Anuncio
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Anuncio()
        {
            return View();
        }
    }
}