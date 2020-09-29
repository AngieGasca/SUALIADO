using Sualiado.Models;
using Sualiado.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sualiado.Controllers
{
    public class ProviderController : Controller
    {
        private SualiadoEntities db = new SualiadoEntities();
        // GET: Provider
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.proveedor.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProviderRequest model)
        {
            

            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.SP_Prove_Agregar(model.Cod_Pers, model.Locacion, model.Enlace, model.Activo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Edit(int cod_prove)
        {
            ProviderRequest model = new ProviderRequest();
            using (db)
            {
                var prove = db.proveedor.Find(cod_prove);
                model.Cod_Pers = prove.Cod_Pers_Fk;
                model.Locacion = prove.Locacion;
                model.Enlace = prove.Enlace;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProviderRequest model)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.SP_Prove_Editar(model.Cod_Pers, model.Locacion, model.Enlace,model.Activo, model.Cod_Prove);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int cod_prove)
        {
            using (db)
            {
                db.SP_Prove_Eliminar(cod_prove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}