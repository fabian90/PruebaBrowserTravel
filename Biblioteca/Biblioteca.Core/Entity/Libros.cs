using Biblioteca.Commons.Repository.Entities;
using System;
using System.Collections.Generic;

namespace Biblioteca.Core.Entity;

public partial class Libros : BaseEntity
{
    public long Isbn { get; set; }

    public int? EditorialesId { get; set; }

    public string? Titulo { get; set; }

    public string? Sinopsis { get; set; }

    public string? NPaginas { get; set; }

    public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; } = new List<AutoresHasLibro>();

    public virtual Editoriales? Editoriales { get; set; }
}
