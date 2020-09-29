using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sualiado.Models
{
    public class CompraModel
    {

        public SelectList listaCategorias { get; set; }
        public SelectList listaSubCategorias { get; set; }
        public SelectList listaProducto { get; set; }
        public SelectList listaProveedores { get; set; }


        public int categoria { get; set; }
        public int subcategoria { get; set; }
        public int producto { get; set; }
        public int Proveedor { get; set; }


    }
}