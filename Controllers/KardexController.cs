using Sualiado.Models;
using Sualiado.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sualiado.Controllers
{
    public class KardexController : Controller
    {
        private SualiadoEntities db = new SualiadoEntities();
        // GET: Kardex
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.kardex.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(KardexRequest model)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.SP_Kr_Agregar(model.Cod_Pers, model.Cod_Mov, model.Cod_Pro, model.Dcto, model.Cantidad, model.Costo, model.Fecha,"");
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View(model);
        }
        

    }

}