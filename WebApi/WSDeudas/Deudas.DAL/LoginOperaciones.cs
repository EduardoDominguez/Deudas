using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.DAL.Modelo;

namespace Deudas.DAL
{
    public class LoginOperaciones
    {
        private DeudasEntities context;

        public usuarios Login(usuarios pUsuario)
        {
            using (context = new DeudasEntities())
            {
                //var blogs = context.usuarios.SqlQuery("SELECT * FROM dbo.Blogs").ToList();
                var usuario = (from s in context.usuarios
                               where s.nick.Equals(pUsuario.nick) && s.contrasena.Equals(pUsuario.contrasena)
                               select s).FirstOrDefault<usuarios>();
                return usuario;
            }
        }
    }
}
