using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.DAL.Modelo;
using Deudas.DAL;


namespace Deudas.BL
{
    public class IngresoNegocio
    {
        public int Agregar(ingresos pIngresos)
        {
            IngresoOperaciones pDatos = new IngresoOperaciones();
            return pDatos.Agregar(pIngresos);
        }

        public List<ingresos> Consultar()
        {
            IngresoOperaciones pDatos = new IngresoOperaciones();
            return pDatos.consultarTodos();
        }
    }
}
