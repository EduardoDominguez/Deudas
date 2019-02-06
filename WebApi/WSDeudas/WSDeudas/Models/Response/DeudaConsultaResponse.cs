using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deudas.DAL.Modelo;

namespace WSDeudas.Models.Response
{
    public class DeudaConsultaResponse : Respuesta
    {
        public List<deudas> Deudas { get; set; }

        public DeudaConsultaResponse()
        {
            if (this.Deudas == null)
                this.Deudas = new List<deudas>();
            else
                this.Deudas.Clear();
        }
    }
}