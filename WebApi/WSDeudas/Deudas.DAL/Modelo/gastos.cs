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
    
    public partial class gastos
    {
        public int idgasto { get; set; }
        public string nombre { get; set; }
        public int estatus { get; set; }
        public int dia_corte { get; set; }
        public int dia_limite_pago { get; set; }
        public System.DateTime fechaalta { get; set; }
        public System.TimeSpan horaalta { get; set; }
        public int idusuario { get; set; }
        public decimal total { get; set; }
    }
}