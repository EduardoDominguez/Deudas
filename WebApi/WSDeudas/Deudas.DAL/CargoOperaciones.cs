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
    public class CargoOperaciones
    {
        private deudasEntities context;

        public E_MENSAJE Agregar(cargos_deudas pCargo)
        {
            /*using (context = new deudasEntities())
            {
                return context.Database.ExecuteSqlCommand(String.Format("insert into cargos_deudas(iddeuda, idusuario, cantidad) values ({0}, {1}, {2})",
                                                    pCargo.iddeuda, pCargo.idusuario, pCargo.cantidad));
            }*/

            using (context = new deudasEntities())
            {
                ObjectParameter RET_NUMEROERROR = new ObjectParameter("RET_NUMEROERROR", typeof(string));
                ObjectParameter RET_MENSAJEERROR = new ObjectParameter("RET_MENSAJEERROR", typeof(string));
                ObjectParameter RET_VALORDEVUELTO = new ObjectParameter("RET_VALORDEVUELTO", typeof(string));


                context.spAddCargo(pCargo.iddeuda, pCargo.idusuario, pCargo.cantidad, RET_NUMEROERROR, RET_MENSAJEERROR, RET_VALORDEVUELTO);

                E_MENSAJE vMensaje = new E_MENSAJE { RET_NUMEROERROR = int.Parse(RET_NUMEROERROR.Value.ToString()), RET_MENSAJEERROR = RET_MENSAJEERROR.Value.ToString(), RET_VALORDEVUELTO = RET_VALORDEVUELTO.Value.ToString() };
                return vMensaje;
            }
        }
    }
}
