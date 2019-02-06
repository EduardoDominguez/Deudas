using Deudas.DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deudas.DAL
{
    public class CargoOperaciones
    {
        private deudasEntities context;

        public int Agregar(cargos_deudas pCargo)
        {
            using (context = new deudasEntities())
            {
                return context.Database.ExecuteSqlCommand(String.Format("insert into deudas.cargos_deudas values (iddeuda, idusuario, cantidad) values({0}, {1}, {2})",
                                                    pCargo.iddeuda, pCargo.idusuario, pCargo.cantidad));
            }
        }
    }
}
