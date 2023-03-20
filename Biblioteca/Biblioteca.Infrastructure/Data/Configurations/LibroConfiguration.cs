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
    public class LibroConfiguration : IEntityTypeConfiguration<Libros>
    {
        public void Configure(EntityTypeBuilder<Libros> entity)
        {
            entity.HasKey(e => e.Isbn);

            entity.ToTable("libros");

            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.EditorialesId).HasColumnName("editoriales_id");
            entity.Property(e => e.NPaginas)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("n_paginas");
            entity.Property(e => e.Sinopsis)
                .IsUnicode(false)
                .HasColumnName("sinopsis");
            entity.Property(e => e.Titulo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Editoriales).WithMany(p => p.Libros)
                .HasForeignKey(d => d.EditorialesId)
                .HasConstraintName("FK_libros_editoriales");
        }
    }
}
