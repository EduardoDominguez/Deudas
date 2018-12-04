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
                context.ingresos.Add(pIngresos);
                return context.SaveChanges();
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
