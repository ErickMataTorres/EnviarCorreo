using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnviarCorreo.Models;
using FirebirdSql.Data.FirebirdClient;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EnviarCorreo.Controllers
{
    public class SaldoController : Controller
    {

        // GET: Saldo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Saldo()
        {
            return View();
        }

        public JsonResult ListaTablaClientes(string cliente)
        {
            var a = Models.Saldo.ListaClientes(cliente);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CargarCliente(int cliente)
        {
            var a = Models.Saldo.Cargar(cliente);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}