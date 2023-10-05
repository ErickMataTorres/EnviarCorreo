using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnviarCorreo.Models;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Security.Policy;

namespace EnviarCorreo.Controllers
{
    public class RegistrarMonederoController : Controller
    {

        // GET: RegistrarMonedero
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrarMonedero()
        {
            return View();

        }

        //public JsonResult CargarId(int id)
        //{
        //    var a = Models.RegistrarMonedero.CargarId(id);
        //    return Json(a, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ValidarMonedero(int id, int idregistrar, int idmonedero, int numeromonedero)
        //{
        //    var a = Models.RegistrarMonedero.ValidarMonedero(id,  idregistrar, idmonedero,  numeromonedero);
        //    return Json(a, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult Consecutivo(int id)
        //{
        //    var a = Models.RegistrarMonedero.Consecutivo(id);
        //    return Json(a, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public string GuardarMonedero(Models.RegistrarMonedero c)
        {
            var a = c.Guardar();
            return a;
            
        }
    }
}