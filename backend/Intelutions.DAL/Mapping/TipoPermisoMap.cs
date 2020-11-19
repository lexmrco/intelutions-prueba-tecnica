using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Intelutions.Entities;

namespace Intelutions.DAL.Mapping
{
    public class TipoPermisoMap : IEntityTypeConfiguration<TipoPermiso>
    {
        public void Configure(EntityTypeBuilder<TipoPermiso> builder)
        {
            builder.ToTable("TipoPermiso")
                .HasMany(c => c.Permisos).WithOne(x => x.TipoPermiso).HasForeignKey(x => x.TipoPermisoId);
            //InitialData(builder);
        }

        private void InitialData(EntityTypeBuilder<TipoPermiso> builder)
        {
            builder.HasData(new TipoPermiso
            {
                Descripcion = "Enfermedad"
            }, new TipoPermiso
            {
                Descripcion = "Diligencias personales"
            }, new TipoPermiso
            {
                Descripcion = "Cita médica"
            }, new TipoPermiso
            {
                Descripcion = "Compensatorio"
            });
        }
    }
}
