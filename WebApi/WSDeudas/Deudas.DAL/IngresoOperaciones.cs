using Deudas.DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deudas.DAL
{
    public class IngresoOperaciones
    {
        private deudasEntities context;

        public int Agregar(ingresos pIngresos)
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
                return context.Database.ExecuteSqlCommand(String.Format("insert into ingresos (nombre, cantidad_inicial, cantidad_actual, fecha, idusuario) values('{0}', {1}, '{2}', {3})",
                                                    pIngresos.nombre, pIngresos.cantidad_inicial, pIngresos.cantidad_inicial, pIngresos.fecha.ToString("yyyy-MM-dd"), pIngresos.idusuario));
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
    }
}
