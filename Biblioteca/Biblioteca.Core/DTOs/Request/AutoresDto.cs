using System;
using System.Collections.Generic;

namespace Biblioteca.Core.DTOs.Request;

public partial class AutoresDto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public virtual ICollection<AutoresHasLibroDto> AutoresHasLibros { get; } = new List<AutoresHasLibroDto>();
}
