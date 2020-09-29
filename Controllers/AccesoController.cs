using Sualiado.Models;
using Sualiado.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sualiado.Controllers
{
    public class AccesoController : Controller
    {
        private SualiadoEntities db = new SualiadoEntities();
        // GET: Acceso
        public ActionResult Index() 
        {

            Session["usuario"] = null;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string correo, string contrasena)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    string password = Encrypt.GetSHA256(contrasena);
                    var usuario = (from p in db.persona
                                   where p.Correo == correo.Trim() &&
                                   p.Contrasena == password.Trim()
                                   select p).FirstOrDefault();
                    if (usuario == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }

                   Session["usuario"] = usuario;
                   if (usuario.Tipo_Rol==1 )
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            return View(correo);
        }

    }
}