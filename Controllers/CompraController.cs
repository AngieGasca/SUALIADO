using Sualiado.Models;
using Sualiado.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sualiado.Controllers
{
    public class CompraController : Controller
    {
        private SualiadoEntities db = new SualiadoEntities();


        // GET: Compra
        public ActionResult Index()
        {
            CompraModel modeloCompras = new CompraModel();

            List<Models.Request.CategoriaModel> datosCategoria = new List<Models.Request.CategoriaModel>();
            List<Models.Request.SubCategoriasModel> datosSubCategoria = new List<Models.Request.SubCategoriasModel>();
            List<Models.Request.ProductRequest> datosProducto = new List<Models.Request.ProductRequest>();

            modeloCompras.listaCategorias = new SelectList(datosCategoria, "Cod_Cat", "Nom_Cat");
            modeloCompras.listaSubCategorias = new SelectList(datosSubCategoria, "Cod_Scat", "Nom_Sbcat");
            modeloCompras.listaProducto  = new SelectList(datosProducto, "Cod_Produc", "Nombre_Produc");

            return View(modeloCompras);
        }


       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ObtenerCategorias()
        {

            var datos = new List<CategoriaModel>();

            bool resultado = true;

            try

            {
                using (db)
                {

                    foreach (var item in db.SP_LISTAR_CATEGORIAS())
                    {
                        CategoriaModel categoriaItem = new CategoriaModel();

                        categoriaItem.Cod_Cat = item.Cod_Cat;
                        categoriaItem.Nom_Cat = item.Nom_Cat;

                        datos.Add(categoriaItem);
                    }


                }
            }

            catch (Exception)

            {

                resultado = false;

            }



            return Json(new { success = resultado, dato = datos },

                        JsonRequestBehavior.AllowGet);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ObtenerSubCategorias(int codCategoria)
        {

            var datos = new List<SubCategoriasModel>();

            bool resultado = true;

            try

            {
                using (db)
                {

                    foreach (var item in db.LISTAR_SUBCATEGORIAS_POR_CATEGORIA(codCategoria)) { 

                        SubCategoriasModel subCategoriaItem = new SubCategoriasModel();

                        subCategoriaItem.Cod_Scat = item.Cod_Scat;
                        subCategoriaItem.Nom_Sbcat = item.Nom_Sbcat;

                        datos.Add(subCategoriaItem);
                    }


                }
            }

            catch (Exception)

            {

                resultado = false;

            }



            return Json(new { success = resultado, dato = datos },

                        JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ObtenerProductos(int codSubCategoria)
        {

            var datos = new List<ProductRequest>();

            bool resultado = true;

            try

            {
                using (db)
                {

                    foreach (var item in db.LISTAR_PRODUCTOS_POR_SUBCATEGORIA(codSubCategoria))
                    {

                        ProductRequest productoItem = new ProductRequest();

                        productoItem.Cod_Produc = item.Cod_Produc;
                        productoItem.Nombre_Produc = item.Nombre_Produc;

                        datos.Add(productoItem);
                    }


                }
            }

            catch (Exception)

            {

                resultado = false;

            }



            return Json(new { success = resultado, dato = datos },

                        JsonRequestBehavior.AllowGet);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GuardarCompra(int codproducto,int txtExistencias, int txtValorTotal)
        {

            var datos = "";

            bool resultado = true;

            try

            {
                using (db)
                {

                    var usuario = (persona)Session["usuario"];              
                    db.SP_Kr_Agregar(Convert.ToInt32(usuario.Cod_Pers), 1, codproducto, 0, txtExistencias, txtValorTotal, DateTime.Now,"");
                    db.SaveChanges();
                    int existenciasPr = 0;
                    foreach (var item in db.SP_OBTENER_EXISTENCIAS_POR_PRODUCTO(codproducto))
                    {
                        existenciasPr = item.Value;
                        break;
                    }

                    db.SP_CREAR_COMPRA(codproducto, existenciasPr + txtExistencias);
                    db.SaveChanges();

                }
            }

            catch (Exception ex)

            {

                resultado = false;

            }



            return Json(new { success = resultado, dato = datos },

                        JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GuardarVenta(int codproducto, int txtExistencias, int txtValorTotal)
        {

            var datos = "";

            bool resultado = true;

            try

            {
                using (db)
                {

                    int existenciasPr = 0;

                    foreach (var item in db.SP_OBTENER_EXISTENCIAS_POR_PRODUCTO(codproducto))
                    {
                        existenciasPr = item.Value;
                        break;
                    }


                    if (existenciasPr != 0 && existenciasPr >= txtExistencias)
                    {
                        var usuario = (persona)Session["usuario"];
                        db.SP_Kr_Agregar(Convert.ToInt32(usuario.Cod_Pers), 2, codproducto, 0, txtExistencias, txtValorTotal, DateTime.Now,"");
                        db.SaveChanges();


                        db.SP_CREAR_COMPRA(codproducto, existenciasPr - txtExistencias);
                        db.SaveChanges();
                    }
                    else
                    {
                        resultado = false;
                    }

                   

                }
            }

            catch (Exception ex)

            {

                resultado = false;

            }



            return Json(new { success = resultado, dato = datos },

                        JsonRequestBehavior.AllowGet);

        }


        public ActionResult IndexVenta() 
        {

            CompraModel modeloCompras = new CompraModel();

            List<Models.Request.CategoriaModel> datosCategoria = new List<Models.Request.CategoriaModel>();
            List<Models.Request.SubCategoriasModel> datosSubCategoria = new List<Models.Request.SubCategoriasModel>();
            List<Models.Request.ProductRequest> datosProducto = new List<Models.Request.ProductRequest>();

            modeloCompras.listaCategorias = new SelectList(datosCategoria, "Cod_Cat", "Nom_Cat");
            modeloCompras.listaSubCategorias = new SelectList(datosSubCategoria, "Cod_Scat", "Nom_Sbcat");
            modeloCompras.listaProducto = new SelectList(datosProducto, "Cod_Produc", "Nombre_Produc");

            return View(modeloCompras);
        }


        public ActionResult IndexDevolucion()
        {

            CompraModel modeloCompras = new CompraModel();

            List<Models.Request.CategoriaModel> datosCategoria = new List<Models.Request.CategoriaModel>();
            List<Models.Request.SubCategoriasModel> datosSubCategoria = new List<Models.Request.SubCategoriasModel>();
            List<Models.Request.ProductRequest> datosProducto = new List<Models.Request.ProductRequest>();
            List<Models.Request.ProviderRequest> datosProveedores= new List<Models.Request.ProviderRequest>();


            modeloCompras.listaCategorias = new SelectList(datosCategoria, "Cod_Cat", "Nom_Cat");
            modeloCompras.listaSubCategorias = new SelectList(datosSubCategoria, "Cod_Scat", "Nom_Sbcat");
            modeloCompras.listaProducto = new SelectList(datosProducto, "Cod_Produc", "Nombre_Produc");
            modeloCompras.listaProveedores = new SelectList(datosProveedores, "Cod_Pers", "NombreCompleto");


            return View(modeloCompras);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ObtenerProveedores()
        {

            var datos = new List<ProviderRequest>();

            bool resultado = true;

            try

            {
                using (db)
                {

                    foreach (var item in db.SP_LISTAR_PROVEEDORES())
                    {
                        ProviderRequest proveedorItem = new ProviderRequest();

                        proveedorItem.NombreCompleto = item.NombreCompleto;
                        proveedorItem.Cod_Pers = item.Cod_Pers;

                        datos.Add(proveedorItem);
                    }


                }
            }

            catch (Exception)

            {

                resultado = false;

            }



            return Json(new { success = resultado, dato = datos },

                        JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GuardarDevolucion(int codproducto, int txtExistencias, int txtValorTotal ,string txtDetalle, int codProveedor)
        {

            var datos = "";

            bool resultado = true;

            try

            {
                using (db)
                {

                    int existenciasPr = 0;

                    foreach (var item in db.SP_OBTENER_EXISTENCIAS_POR_PRODUCTO(codproducto))
                    {
                        existenciasPr = item.Value;
                        break;
                    }


                    if (existenciasPr != 0 && existenciasPr >= txtExistencias)
                    {

                        var usuario = (persona)Session["usuario"];
                        db.SP_Kr_Agregar(usuario.Cod_Pers, 3, codproducto, 0, txtExistencias, txtValorTotal, DateTime.Now, txtDetalle);
                        db.SaveChanges();


                        db.SP_CREAR_COMPRA(codproducto, existenciasPr - txtExistencias);
                        db.SaveChanges();
                    }
                    else
                    {
                        resultado = false;
                    }



                }
            }

            catch (Exception ex)

            {

                resultado = false;

            }



            return Json(new { success = resultado, dato = datos },

                        JsonRequestBehavior.AllowGet);

        }

    }
}