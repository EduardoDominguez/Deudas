using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deudas.EL
{
    public class Usuario
    {
        public int idusuario {get; set;}
        public String nombre { get; set; }
        public String appaterno { get; set; }
        public String apmaterno { get; set; }
        public int idusuarioregistro { get; set; }
        public String horaregistro { get; set; }
        public String fecharegistro { get; set; }
        public String correo { get; set; }
        public String nick { get; set; }
        public String contrasena { get; set; } 
    }
}
