using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deudas.DAL.Modelo;

namespace WSDeudas.Models.Request
{
    public class DeudasRequest
    {
        public string Nombre { get; set; }
        public short DiaCorte { get; set; }
        public int DiaLimitePago { get; set; }
        public int IdUsuario { get; set; }

        public DeudasRequest()
        {
            this.Nombre = string.Empty;
            this.DiaCorte = 0;
            this.DiaLimitePago = 0;
            this.IdUsuario = 0;
        }
    }
}