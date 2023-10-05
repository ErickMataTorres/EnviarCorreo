using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnviarCorreo.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult CorreoVerficado()
        {
            return View();
        }

        public ActionResult MiPerfil()
        {
            return View();
        }

        
        public JsonResult Verificador()
        {
            var a = Models.Cliente.ConsultarVerificador();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

    
        public string VerificarUsuario(Models.Cliente c)
        {
            var a = c.VerificarUsuario();
            return a;
        }

       

     
        public JsonResult ValidarUsuario(string correo, string contraseña)
        {
            var a = Models.Cliente.ValidarCorreo(correo, contraseña);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        [HttpPost] 
       
        public string RegistrarUsuario(Models.Cliente c)
        {
            var a = c.RegistrarUsuario();
            return a;
        }

        public string Guardar(Models.Cliente c)
        {
            var a = c.Guardar();
            return a;
        }
    }
}