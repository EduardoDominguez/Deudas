using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models
{
    public class Respuesta
    {
        public string Mensaje{ get; set; }
        public bool Exito { get; set; }
        public string CodigoError { get; set; }

        public Respuesta()
        {
            Inicializar();
        }

        public void Inicializar()
        {
            this.Mensaje = string.Empty;
            this.Exito = false;
            this.CodigoError = string.Empty;
        }
    }
}