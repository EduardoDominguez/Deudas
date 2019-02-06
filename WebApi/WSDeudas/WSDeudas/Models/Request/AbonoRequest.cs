using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models.Request
{
    public class AbonoRequest
    {
        public int IdIngreso { get; set; }
        public int IdUsuario { get; set; }
        public int IdDeuda { get; set; }
        public decimal Cantidad { get; set; }

        public AbonoRequest()
        {
            this.IdIngreso = 0;
            this.IdDeuda = 0;
            this.Cantidad = 0;
            this.IdUsuario = 0;
        }
    }
}