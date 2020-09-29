using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sualiado.Models.Request
{
    public class KardexRequest
    {
        public int Consecut { get; set; }
        [Required]
        [StringLength(2)]
        public int Cod_Pers { get; set; }
        [Required]
        [StringLength(1)]
        public int Cod_Mov { get; set; }
        [Required]
        [StringLength(2)]
        public int Cod_Pro { get; set; }
        [Required]
        [StringLength(50)]
        public int Dcto { get; set; }
        [Required]
        [StringLength(50)]
        public int Cantidad { get; set;}
        [Required]
        [StringLength(50)]
        public int Costo { get; set; }
        [Required]
        [StringLength(50)]
        public DateTime Fecha { get; set;}

    }
}