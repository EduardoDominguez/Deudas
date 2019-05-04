using Deudas.DAL.Modelo;
using Deudas.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deudas.DAL
{
    public class IngresoOperaciones
    {
        private deudasEntities context;

        public E_MENSAJE Agregar(E_INGRESO pIngreso)
        {
            using (context = new deudasEntities())
            {
                /*using (var transaction = context.Database.BeginTransaction())
                {

                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[ingresos] ON");

                    context.ingresos.Add(pIngresos);
                    var res = context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[ingresos] OFF");

                    transaction.Commit();

                    return res;
                }*/
                /*return context.Database.ExecuteSqlCommand(String.Format("insert into ingresos (nombre, cantidad_inicial, cantidad_actual, fecha, idusuario) values ('{0}', {1}, {2}, '{3}', {4})",
                                                    pIngreso.Nombre, pIngreso.Cantidad, pIngreso.Cantidad, pIngreso.Fecha, pIngreso.IdUsuario));*/


                ObjectParameter RET_NUMEROERROR = new ObjectParameter("RET_NUMEROERROR", typeof(string));
                ObjectParameter RET_MENSAJEERROR = new ObjectParameter("RET_MENSAJEERROR", typeof(string));
                ObjectParameter RET_VALORDEVUELTO = new ObjectParameter("RET_VALORDEVUELTO", typeof(string));


                context.spAddIngreso(pIngreso.Nombre, pIngreso.Fecha, pIngreso.IdUsuario, pIngreso.Cantidad, RET_NUMEROERROR, RET_MENSAJEERROR, RET_VALORDEVUELTO);

                E_MENSAJE vMensaje = new E_MENSAJE { RET_NUMEROERROR = int.Parse(RET_NUMEROERROR.Value.ToString()), RET_MENSAJEERROR = RET_MENSAJEERROR.Value.ToString(), RET_VALORDEVUELTO = RET_VALORDEVUELTO.Value.ToString() };
                return vMensaje;
            }
        }

        public List<ingresos> consultarTodos()
        {
            using (context = new deudasEntities())
            {
                var ingresos = (from s in context.ingresos
                               select s).ToList<ingresos>();
                return ingresos;
            }
        }

        public List<ingresos> ConsultarPorId(int pIdIngreso)
        {
            using (context = new deudasEntities())
            {
                var ingresos = (from s in context.ingresos
                                where s.idingreso == pIdIngreso
                                select s).ToList<ingresos>();
                return ingresos;
            }
        }

        public List<ingresos> ConsultarPorUsuairo(int pIdUsuario)
        {
            using (context = new deudasEntities())
            {
                var ingresos = (from s in context.ingresos
                                where s.idusuario == pIdUsuario
                                select s).ToList<ingresos>();
                return ingresos;
            }
        }

        public List<ingresos> consultarConSaldo()
        {
            using (context = new deudasEntities())
            {
                var ingresos = (from s in context.ingresos
                                where s.cantidad_actual > 0
                                select s).ToList<ingresos>();
                return ingresos;
            }
        }

        public decimal ConsultaSumatoria(int pIdUsuario)
        {
            decimal total = 0;
            using (context = new deudasEntities())
            {
                var ingresos = (from s in context.ingresos
                                where s.cantidad_actual > 0
                                && s.idusuario == pIdUsuario
                                select s).ToList<ingresos>();

                total = ingresos.Sum(i => i.cantidad_actual)??0;
                
            }

            return total;

        }

        
    }
}
