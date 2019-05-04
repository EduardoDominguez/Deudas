using Deudas.DAL.Modelo;
using Deudas.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deudas.DAL
{
    public class DeudaOperaciones
    {
        private deudasEntities context;

        public int Agregar(deudas pDeudas)
        {
            using (context = new deudasEntities())
            {
                return context.Database.ExecuteSqlCommand(String.Format("insert into deudas (nombre, dia_corte, dia_limite_pago, idusuario) values('{0}', {1}, {2}, {3})",
                                                    pDeudas.nombre, pDeudas.dia_corte, pDeudas.dia_limite_pago, pDeudas.idusuario));
                //return context.SaveChanges();
            }
        }

        public List<deudas> consultarTodos()
        {
            using (context = new deudasEntities())
            {
                var deudas = (from s in context.deudas
                              select s).ToList<deudas>();
                return deudas;
            }
        }


        public List<deudas> ConsultarPorId(int pIdDeuda)
        {
            using (context = new deudasEntities())
            {
                var deudas = (from s in context.deudas
                              where s.iddeuda == pIdDeuda
                              select s).ToList<deudas>();
                return deudas;
            }
        }

        public List<deudas> ConsultarPorIdUsuario(int pIdUsuario)
        {
            //List<E_DEUDAS> deudas;
            using (context = new deudasEntities())
            {
                var deudas = (from s in context.deudas
                              where s.idusuario == pIdUsuario
                              select s).ToList<deudas>();

                return deudas;
            }
        }



        public decimal ConsultaSumatoriaCargos(int pIdUsuario)
        {
            using (context = new deudasEntities())
            {
                return context.Database.SqlQuery<decimal>("select sum(cantidad) from deudas d inner join cargos_deudas cd on d.iddeuda = cd.iddeuda where d.idusuario = "+ pIdUsuario + " group by d.idusuario").ToList().FirstOrDefault();
               
            }
        }


    }
}
