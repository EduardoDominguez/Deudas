using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models.Request
{
    public class IngresosRequest 
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }

        public IngresosRequest()
        {
            this.Nombre = string.Empty;
            this.Cantidad = 0;
            this.Fecha = DateTime.Now;
        }
    }
}