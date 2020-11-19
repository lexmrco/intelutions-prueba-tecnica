using Microsoft.EntityFrameworkCore;
using Intelutions.DAL.Mapping;
using Intelutions.Entities;
using System;

namespace Intelutions.DAL
{
    public class IntelutionsDbContext : DbContext
    {
        public IntelutionsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TipoPermiso> TiposPermisos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermisoMap());
            modelBuilder.ApplyConfiguration(new TipoPermisoMap());

        }
    }
}
