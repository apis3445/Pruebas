using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pruebas.Modelos
{
    public class AutorConfig : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasIndex(e => e.Clave)
                         .HasName("UX_AutorClave")
                         .IsUnique();
        }
    }
}
