using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sualiado.Models.Request
{
    public class PersonRequest
    {
        public int Cod_Pers { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Nombre")]
        public string Nom_Pers { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Apellido")]
        public string Ape_Pers { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Tipo de identificación")]
        public string Tipo_Iden { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Numero de identificación")]
        public string Nro_Iden { get; set; }
        [Required]
        [DisplayName("Fecha de Nacimiento")]
        public DateTime Fec_Nac { get; set; }
        [Required]
        [StringLength(60)]
        [DisplayName("Correo")]
        public string Correo { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Contrasena")]
        public string Contrasena { get; set; }

        [Required]
        public int Tipo_Rol { get; set; }

    }
}