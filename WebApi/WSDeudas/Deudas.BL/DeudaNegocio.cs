using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.DAL.Modelo;
using Deudas.DAL;


namespace Deudas.BL
{
    public class DeudaNegocio
    {
        public int Agregar(deudas pDeudas)
        {
            DeudaOperaciones pDatos = new DeudaOperaciones();
            return pDatos.Agregar(pDeudas);
        }

        public List<deudas> Consultar()
        {
            DeudaOperaciones pDatos = new DeudaOperaciones();
            return pDatos.consultarTodos();
        }

        public List<deudas> ConsultarPorId(int pIdDeuda)
        {
            DeudaOperaciones pDatos = new DeudaOperaciones();
            return pDatos.ConsultarPorId(pIdDeuda);
        }
    }
}
