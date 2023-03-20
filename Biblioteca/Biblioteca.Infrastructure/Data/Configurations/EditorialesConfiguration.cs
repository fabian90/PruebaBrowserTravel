using Biblioteca.Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Data.Configurations
{
    public class EditorialesConfiguration : IEntityTypeConfiguration<Editoriales>
    {
        public void Configure(EntityTypeBuilder<Editoriales> entity)
        {
            entity.ToTable("editoriales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sede)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("sede");
        }
    }
}
