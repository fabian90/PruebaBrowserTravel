using Biblioteca.Commons.Repository.Entities;
using System;
using System.Collections.Generic;

namespace Biblioteca.Core.Entity;

public partial class AutoresHasLibro : BaseEntity
{
    public int Id { get; set; }
    public int AutoresId { get; set; }

    public long LibrosIsbn { get; set; }

    public virtual Autores Autores { get; set; } = null!;

    public virtual Libros LibrosIsbnNavigation { get; set; } = null!;
}
