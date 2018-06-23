using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RegistroArticulosP.Entidades;

namespace RegistroArticulosP.DALL
{
    public class Contexto : DbContext
    {
        
            public DbSet<ArticulosProductos> ArticulosP { get; set; }
            public DbSet<Persona> personas { get; set; }
            public DbSet<Cotizacion> cotizacions  { get; set; }

        public Contexto() : base("ConStr")
            {  }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder); 
        }

}
}
