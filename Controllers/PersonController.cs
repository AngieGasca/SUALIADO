using Sualiado.Models;
using Sualiado.Models.Request;
using Sualiado.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sualiado.Controllers
{
    public class PersonController : Controller
    {
        private SualiadoEntities db = new SualiadoEntities();
        // GET: Person
        [HttpGet]
        public ActionResult Index(persona objPersona = null)
        {
            if (objPersona.Mensaje != null && objPersona.Mensaje != "")
            {
                ViewBag.Mensaje = objPersona.Mensaje;
            }



            return View(db.persona.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PersonRequest model)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.SP_Per_Agregar(model.Nom_Pers, model.Ape_Pers, model.Tipo_Iden, model.Nro_Iden, model.Fec_Nac, model.Correo, model.Telefono, Encrypt.GetSHA256(model.Contrasena) ,model.Tipo_Rol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int cod)
        {
            PersonRequest model = new PersonRequest();
            using (db)
            {
                var per = db.persona.Find(cod);
                model.Nom_Pers = per.Nom_Pers;
                model.Ape_Pers = per.Ape_Pers;
                model.Tipo_Iden = per.Tipo_Iden;
                model.Nro_Iden = per.Nro_Iden;
                model.Fec_Nac = per.Fec_Nac;
                model.Correo = per.Correo;
                model.Telefono = per.Telefono;
                model.Cod_Pers = per.Cod_Pers;
                model.Contrasena = per.Contrasena;
                model.Tipo_Rol = per.Tipo_Rol;


            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(PersonRequest model)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.SP_Per_Editar(model.Nom_Pers, model.Ape_Pers, model.Tipo_Iden, model.Nro_Iden, model.Fec_Nac, model.Correo, model.Telefono, model.Cod_Pers, model.Contrasena, model.Tipo_Rol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int cod)
        {
            persona objPersona = new persona();
            using (db)
            {
               

                var existeRe = db.SP_VALIDAR_RELACION_PERSONA(cod).FirstOrDefault() == null ? 0 : db.SP_VALIDAR_RELACION_PERSONA(cod).FirstOrDefault().Value;
                if (existeRe == 0)
                {
                    db.SP_Per_Eliminar(cod);
                    db.SaveChanges();
                }
                else
                {
                    objPersona.Mensaje = "No se puede eliminar el registro por que existe una relacion vigente";
                }




            }
            return RedirectToAction("Index", objPersona);
        }
    }
}