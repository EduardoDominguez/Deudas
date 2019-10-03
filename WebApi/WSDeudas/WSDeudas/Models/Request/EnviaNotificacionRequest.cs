using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models.Request
{
    public class EnviaNotificacionRequest
    {
        
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Correo { get; set; }


        public EnviaNotificacionRequest()
        {
            this.Titulo = string.Empty;
            this.Mensaje = string.Empty;
            this.Correo = string.Empty;
        }
        
    }
}