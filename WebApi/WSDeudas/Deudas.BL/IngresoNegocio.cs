using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.DAL.Modelo;
using Deudas.DAL;
using Deudas.EL;


namespace Deudas.BL
{
    public class IngresoNegocio
    {
        public E_MENSAJE Agregar(E_INGRESO pIngreso)
        {
            IngresoOperaciones pDatos = new IngresoOperaciones();
            return pDatos.Agregar(pIngreso);
        }

        public List<ingresos> Consultar()
        {
            IngresoOperaciones pDatos = new IngresoOperaciones();
            return pDatos.consultarTodos();
        }

        public List<ingresos> ConsultarPorId(int pIdIngreso)
        {
            IngresoOperaciones pDatos = new IngresoOperaciones();
            return pDatos.ConsultarPorId(pIdIngreso);
        }


        public List<ingresos> ConsultarPorUsuario(int pIdUsuario)
        {
            IngresoOperaciones pDatos = new IngresoOperaciones();
            return pDatos.ConsultarPorUsuairo(pIdUsuario);
        }


        public decimal ConsultaSumatoria(int pIdUsuario)
        {
            IngresoOperaciones pDatos = new IngresoOperaciones();
            return pDatos.ConsultaSumatoria(pIdUsuario);
        }

    }
}
