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
    public class UsuarioNegocio
    {

        public E_MENSAJE Agregar(usuarios pUsuario)
        {
            UsuarioOperaciones pDatos = new UsuarioOperaciones();
            return pDatos.Agregar(pUsuario);
        }
    }
}