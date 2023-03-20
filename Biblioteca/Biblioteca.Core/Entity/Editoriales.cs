using Biblioteca.Commons.Repository.Entities;
using System;
using System.Collections.Generic;

namespace Biblioteca.Core.Entity;

public partial class Editoriales : BaseEntity
{
    public int Id { get; set; }
    public string? Nombre { get; set; }

    public string? Sede { get; set; }

    public virtual ICollection<Libros> Libros { get; } = new List<Libros>();
}
