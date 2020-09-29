using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sualiado.Models.Request
{
    public class ProviderRequest
    {
        public int Cod_Prove { get; set; }

        [Required]
        public int Cod_Pers { get; set; }

        [Required]
        [DisplayName("Locacion")]
        public string Locacion { get; set; }

        [Required]
        [DisplayName("Enlace")]
        public string Enlace { get; set; }


        public bool Activo { get; set; }


        public string NombreCompleto { get; set; }

    }
}