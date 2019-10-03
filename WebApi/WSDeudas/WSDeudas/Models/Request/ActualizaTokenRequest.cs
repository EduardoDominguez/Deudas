using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models.Request
{
    public class ActualizaTokenRequest
    {
        public int IdUsuario { get; set; }
        public string Token { get; set; }


        public ActualizaTokenRequest()
        {
            this.IdUsuario = 0;
            this.Token = string.Empty;
        }
    }
}