using Deudas.DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.EL;
using System.Data.Entity.Core.Objects;
namespace Deudas.DAL
{
    public class UsuarioOperaciones
    {
        private deudasEntities context;

        public E_MENSAJE Agregar(usuarios pUsuarios)
        {
            using (context = new deudasEntities())
            {
                ObjectParameter RET_NUMEROERROR = new ObjectParameter("RET_NUMEROERROR", typeof(string));
                ObjectParameter RET_MENSAJEERROR = new ObjectParameter("RET_MENSAJEERROR", typeof(string));
                ObjectParameter RET_VALORDEVUELTO = new ObjectParameter("RET_VALORDEVUELTO", typeof(string));


                context.spAddUsuario(pUsuarios.nombre, pUsuarios.appaterno, pUsuarios.apmaterno, pUsuarios.nick, pUsuarios.correo, pUsuarios.contrasena, RET_NUMEROERROR, RET_MENSAJEERROR, RET_VALORDEVUELTO);

                E_MENSAJE vMensaje = new E_MENSAJE { RET_NUMEROERROR = int.Parse(RET_NUMEROERROR.Value.ToString()), RET_MENSAJEERROR = RET_MENSAJEERROR.Value.ToString(), RET_VALORDEVUELTO = RET_VALORDEVUELTO.Value.ToString() };
                return vMensaje;
            }
        }
    }
}
