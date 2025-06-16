using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    public class Sist_ControlActivos2Context : DbContext
    {
        public Sist_ControlActivos2Context()
            : base("name=Sist_ControlActivos2") 
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Barrio> Barrios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoDeActivo> TipoDeActivos { get; set; }
        public DbSet<EstadoActual> EstadoActuals { get; set; }
        public DbSet<Activos> Activos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TipoUser> TipoUsers { get; set; }
        /*public DbSet<Depreciacion> Depreciaciones { get; set; }
        public DbSet<DetallesMantenimiento> DetallesMantenimientos { get; set; }
        public DbSet<TipoMantenimiento> TipoMantenimientos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<HistorialMovimiento> HistorialMovimientos { get; set; }*/
        public DbSet<Adquisicion> Adquisiciones { get; set; }
    }
}
