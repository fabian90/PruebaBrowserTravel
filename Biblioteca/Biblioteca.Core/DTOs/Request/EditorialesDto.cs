using System;
using System.Collections.Generic;

namespace Biblioteca.Core.DTOs.Request;

public partial class EditorialesDto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Sede { get; set; }

    public virtual ICollection<LibrosDto> Libros { get; } = new List<LibrosDto>();
}
