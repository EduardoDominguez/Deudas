using Deudas.DAL.Modelo;
using Deudas.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deudas.DAL
{
    public class NotificacionOperaciones
    {
        private deudasEntities context;

        public string ObtieneToken(string pCorreo)
        {
            using (context = new deudasEntities())
            {
                return context.Database.SqlQuery<string>(string.Format("select token from usuarios where correo = '{0}'", pCorreo)).ToList().FirstOrDefault();
            }
        }



        public int ActualizaToken(int pIdUsuario, string pToken)
        {
            using (context = new deudasEntities())
            {
                return context.Database.ExecuteSqlCommand(String.Format("update usuarios set token = '{0}' where idusuario = {1}",
                                                   pToken, pIdUsuario));
                //return context.SaveChanges();
            }
        }


    }
}
