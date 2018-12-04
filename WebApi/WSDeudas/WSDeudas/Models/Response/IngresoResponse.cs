using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deudas.DAL.Modelo;

namespace WSDeudas.Models.Response
{
    public class IngresoResponse :Respuesta
    {
        public List<ingresos> Ingresos { get; set; }

        public IngresoResponse()
        {
            if (this.Ingresos == null)
                this.Ingresos = new List<ingresos>();
            else
                this.Ingresos.Clear();
        }
    }
}