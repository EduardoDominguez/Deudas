using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.DAL.Modelo;
using Deudas.DAL;

namespace Deudas.BL
{
    public class LoginNegocio
    {
        
        public usuarios Login(usuarios pUsuario)
        {
            LoginOperaciones pDatos = new LoginOperaciones();
            return pDatos.Login(pUsuario);
        }
    }
}
