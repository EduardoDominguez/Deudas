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
    public class AbonoOperaciones
    {
        private deudasEntities context;

        /*public int Agregar(abonos_deuda pCargo)
        {
            using (context = new deudasEntities())
            {
                return context.Database.ExecuteSqlCommand(String.Format("insert into deudas.cargos_deudas values (iddeuda, idusuario, cantidad) values({0}, {1}, {2})",
                                                    pCargo.iddeuda, pCargo.idusuario, pCargo.cantidad));
            }
        }*/

        public E_MENSAJE Agregar(abonos_deuda pAbono)
        {
            using (context = new deudasEntities())
            {
                ObjectParameter RET_NUMEROERROR = new ObjectParameter("RET_NUMEROERROR", typeof(string));
                ObjectParameter RET_MENSAJEERROR = new ObjectParameter("RET_MENSAJEERROR", typeof(string));
                ObjectParameter RET_VALORDEVUELTO = new ObjectParameter("RET_VALORDEVUELTO", typeof(string));

                /*var Cantidad = new SqlParameter("@Cantidad", _msg.FID);
                var IdDeuda = new SqlParameter("@IdDeuda", _msg.FID);
                var IdIngreso = new SqlParameter("@IdIngreso", _msg.FID);
                var IdUsuario = new SqlParameter("@IdUsuario", _msg.FID);
                var RET_NUMEROERROR = new SqlParameter("@RET_NUMEROERROR", System.Data.SqlDbType.Int);
                var RET_MENSAJEERROR = new SqlParameter("@RET_MENSAJEERROR", _msg.MSubject);
                var RET_VALORDEVUELTO = new SqlParameter("@RET_VALORDEVUELTO", _msg.MBody);*/

                context.spAddEditAbono(pAbono.cantidad, pAbono.iddeuda, pAbono.idingreso, pAbono.idusuario, RET_NUMEROERROR, RET_MENSAJEERROR, RET_VALORDEVUELTO);

                E_MENSAJE vMensaje = new E_MENSAJE { RET_NUMEROERROR = int.Parse(RET_NUMEROERROR.Value.ToString()), RET_MENSAJEERROR = RET_MENSAJEERROR.Value.ToString(), RET_VALORDEVUELTO = RET_VALORDEVUELTO.Value.ToString() };
                return vMensaje;
            }
        }
    }
}
