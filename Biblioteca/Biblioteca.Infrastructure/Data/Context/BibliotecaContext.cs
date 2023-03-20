using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Core.Entity;
using System.Reflection;

namespace Biblioteca.Infrastructure.Data.Context;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autores> Autores { get; set; } = null!;

    public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; } = null!;

    public virtual DbSet<Editoriales> Editoriales { get; set; } = null!;

    public virtual DbSet<Libros> Libros { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
