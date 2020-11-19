using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Intelutions.Entities;

namespace Intelutions.DAL.Mapping
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("Permiso")
                .HasOne(c => c.TipoPermiso).WithMany().HasForeignKey(x => x.TipoPermisoId);
        }
    }
}
