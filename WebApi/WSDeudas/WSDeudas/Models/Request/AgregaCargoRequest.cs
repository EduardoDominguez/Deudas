using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models.Request
{

    public class AgregaCargoRequest
    {
        public int IdUsuario { get; set; }
        public int IdDeuda { get; set; }
        public decimal Cantidad { get; set; }

        public AgregaCargoRequest()
        {
            this.IdDeuda = 0;
            this.Cantidad = 0;
            this.IdUsuario = 0;
        }
    }
}