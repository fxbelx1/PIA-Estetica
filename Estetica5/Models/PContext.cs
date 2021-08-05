using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Estetica5.Models
{
    public class PContext: DbContext
    {
        public PContext() : base("PConnection")
        {

        }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}