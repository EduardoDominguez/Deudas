﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class deudasEntities : DbContext
    {
        public deudasEntities()
            : base("name=deudasEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<abonos_deuda> abonos_deuda { get; set; }
        public virtual DbSet<cargos_deudas> cargos_deudas { get; set; }
        public virtual DbSet<detalle_deuda> detalle_deuda { get; set; }
        public virtual DbSet<deudas> deudas { get; set; }
        public virtual DbSet<gastos> gastos { get; set; }
        public virtual DbSet<ingresos> ingresos { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
    
        public virtual int spAddEditAbono(Nullable<decimal> cantidad, Nullable<int> idDeuda, Nullable<int> idIngreso, Nullable<int> idUsuario, ObjectParameter rET_NUMEROERROR, ObjectParameter rET_MENSAJEERROR, ObjectParameter rET_VALORDEVUELTO)
        {
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(decimal));
    
            var idDeudaParameter = idDeuda.HasValue ?
                new ObjectParameter("IdDeuda", idDeuda) :
                new ObjectParameter("IdDeuda", typeof(int));
    
            var idIngresoParameter = idIngreso.HasValue ?
                new ObjectParameter("IdIngreso", idIngreso) :
                new ObjectParameter("IdIngreso", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddEditAbono", cantidadParameter, idDeudaParameter, idIngresoParameter, idUsuarioParameter, rET_NUMEROERROR, rET_MENSAJEERROR, rET_VALORDEVUELTO);
        }
    
        public virtual int spAddUsuario(string nombre, string apepaterno, string apematerno, string nick, string correo, string contrasena, ObjectParameter rET_NUMEROERROR, ObjectParameter rET_MENSAJEERROR, ObjectParameter rET_VALORDEVUELTO)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apepaternoParameter = apepaterno != null ?
                new ObjectParameter("Apepaterno", apepaterno) :
                new ObjectParameter("Apepaterno", typeof(string));
    
            var apematernoParameter = apematerno != null ?
                new ObjectParameter("Apematerno", apematerno) :
                new ObjectParameter("Apematerno", typeof(string));
    
            var nickParameter = nick != null ?
                new ObjectParameter("Nick", nick) :
                new ObjectParameter("Nick", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddUsuario", nombreParameter, apepaternoParameter, apematernoParameter, nickParameter, correoParameter, contrasenaParameter, rET_NUMEROERROR, rET_MENSAJEERROR, rET_VALORDEVUELTO);
        }
    
        public virtual int spAddCargo(Nullable<int> idDeuda, Nullable<int> idUsuario, Nullable<decimal> cantidad, ObjectParameter rET_NUMEROERROR, ObjectParameter rET_MENSAJEERROR, ObjectParameter rET_VALORDEVUELTO)
        {
            var idDeudaParameter = idDeuda.HasValue ?
                new ObjectParameter("IdDeuda", idDeuda) :
                new ObjectParameter("IdDeuda", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddCargo", idDeudaParameter, idUsuarioParameter, cantidadParameter, rET_NUMEROERROR, rET_MENSAJEERROR, rET_VALORDEVUELTO);
        }
    
        public virtual int spAddIngreso(string nombre, string fecha, Nullable<int> idUsuario, Nullable<decimal> cantidad, ObjectParameter rET_NUMEROERROR, ObjectParameter rET_MENSAJEERROR, ObjectParameter rET_VALORDEVUELTO)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fechaParameter = fecha != null ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(string));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddIngreso", nombreParameter, fechaParameter, idUsuarioParameter, cantidadParameter, rET_NUMEROERROR, rET_MENSAJEERROR, rET_VALORDEVUELTO);
        }
    }
}
