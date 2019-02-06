using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.DAL;
using Deudas.DAL.Modelo;
using Deudas.EL;

namespace Deudas.BL
{
    public class AbonoNegocio
    {

        public E_MENSAJE Agregar(abonos_deuda pAbono)
        {
            AbonoOperaciones pDatos = new AbonoOperaciones();
            return pDatos.Agregar(pAbono);
        }
    }
}
