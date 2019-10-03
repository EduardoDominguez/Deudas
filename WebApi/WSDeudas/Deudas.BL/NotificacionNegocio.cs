using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.DAL.Modelo;
using Deudas.DAL;


namespace Deudas.BL
{
    public class NotificacionNegocio
    {
        public string ObtieneToken(string pCorreo)
        {
            NotificacionOperaciones pDatos = new NotificacionOperaciones();
            return pDatos.ObtieneToken(pCorreo);
        }

        public int ActualizaToken(int pIdUsuario, string pToken)
        {
            NotificacionOperaciones pDatos = new NotificacionOperaciones();
            return pDatos.ActualizaToken(pIdUsuario, pToken);
        }
    }
}
