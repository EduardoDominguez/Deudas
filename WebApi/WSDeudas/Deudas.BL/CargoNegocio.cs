using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deudas.DAL.Modelo;
using Deudas.DAL;

namespace Deudas.BL
{
    public class CargoNegocio
    {

        public int AgregarCargo(cargos_deudas pCargo)
        {
            CargoOperaciones pDatos = new CargoOperaciones();
            return pDatos.Agregar(pCargo);
        }
    }
}
