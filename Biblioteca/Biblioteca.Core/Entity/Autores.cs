using Biblioteca.Commons.Repository.Entities;
using System;
using System.Collections.Generic;

namespace Biblioteca.Core.Entity;

public partial class Autores : BaseEntity
{
    public int Id { get; set; }
    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; } = new List<AutoresHasLibro>();
}
