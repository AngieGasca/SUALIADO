using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sualiado.Models.Request
{
    public class ProductRequest
    {
        public int Cod_Produc { get; set; }
       
        [Required]
        public int? Cod_Subca { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre_Produc { get; set; }

        
        [Required]
        public int Existencia { get; set; }
       
        [Required]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
        public string Precio_Vta { get; set; }

        [Required]
        public bool Activo { get; set; }

    }
}