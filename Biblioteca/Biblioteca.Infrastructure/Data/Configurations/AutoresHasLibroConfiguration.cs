using Biblioteca.Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Core;

namespace Biblioteca.Infrastructure.Data.Configurations
{
    public class AutoresHasLibroConfiguration : IEntityTypeConfiguration<AutoresHasLibro>
    {
        public void Configure(EntityTypeBuilder<AutoresHasLibro> entity)
        {
            entity.ToTable("autoreshaslibros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AutoresId).HasColumnName("autores_id");
            entity.Property(e => e.LibrosIsbn).HasColumnName("libros_ISBN");

            entity.HasOne(d => d.Autores).WithMany(p => p.AutoresHasLibros)
                .HasForeignKey(d => d.AutoresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autores_has_libros_autores");

            entity.HasOne(d => d.LibrosIsbnNavigation).WithMany(p => p.AutoresHasLibros)
                .HasForeignKey(d => d.LibrosIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autores_has_libros_libros");
        }
    }
}
