using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deudas.EL
{
    [Serializable]
    public class E_DEUDAS
    {
        public int iddeuda { get; set; }
        public int dia_corte { get; set; }
        public int dia_limite_pago { get; set; }
        public string nombre { get; set; }
        public decimal cantidad { get; set; }
    }
}
