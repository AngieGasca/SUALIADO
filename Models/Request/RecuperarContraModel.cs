using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sualiado.Models.Request
{
    public class RecuperarContraModel
    {
       
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Mensaje { get; set; }

    }
}