using Sualiado.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sualiado.Models.Request;

namespace Sualiado.Controllers
{
    public class ProductController : Controller
    {
        private SualiadoEntities db = new SualiadoEntities();
        // GET: Product
        [HttpGet]
        public ActionResult Index(producto objProducto = null)
        {
            if (objProducto != null && objProducto.Mensaje != null)
            {
                ViewBag.Mensaje = objProducto.Mensaje;
            }

            return View(db.producto.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProductRequest model)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.SP_Pro_Agregar(model.Cod_Subca,model.Nombre_Produc,0,model.Precio_Vta,false);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int cod_produc)
        {
            ProductRequest model = new ProductRequest();
            using (db)
            {
                var pro = db.producto.Find(cod_produc);
                model.Cod_Subca = pro.Cod_SubCategoria;
                model.Nombre_Produc = pro.Nombre_Produc;
               //¿ model.Existencia = pro.Existencia;
                model.Precio_Vta = pro.Precio_Venta;
               // model.Activo = pro.Activo;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductRequest model)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.SP_Pro_Editar(model.Cod_Subca, model.Nombre_Produc,0, model.Precio_Vta,true, model.Cod_Produc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int cod_produc)
        {
            producto objProducto = new producto();
            using (db)
            {

                var existeRe = db.SP_VALIDAR_RELACION_PRODUCTO(cod_produc).FirstOrDefault() == null ? 0 : db.SP_VALIDAR_RELACION_PRODUCTO(cod_produc).FirstOrDefault().Value;
                if (existeRe == 0)
                {
                    db.SP_Pro_Eliminar(cod_produc);
                    db.SaveChanges();
                }
                else
                {
                    objProducto.Mensaje = "No se puede eliminar el registro por que existe una relacion vigente";
                }


               
            }
            return RedirectToAction("Index", objProducto);
        }
        
    }
}