using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models.Response
{
    public class ConsultaTotalDeudasResponse : Respuesta
    {
        public decimal Total { get; set; }
    }
}