//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deudas.DAL.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class abonos_deuda
    {
        public int idabono { get; set; }
        public int iddeuda { get; set; }
        public int idusuario { get; set; }
        public Nullable<int> idingreso { get; set; }
        public decimal cantidad { get; set; }
        public System.DateTime fechahora { get; set; }
    
        public virtual deudas deudas { get; set; }
        public virtual ingresos ingresos { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
