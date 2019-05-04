using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deudas.EL
{
    public class E_INGRESO
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public int IdUsuario { get; set; }

        public E_INGRESO()
        {
            this.Nombre = string.Empty;
            this.Cantidad = 0;
            this.Fecha = string.Empty;
            this.IdUsuario = 0;
        }
    }
}
