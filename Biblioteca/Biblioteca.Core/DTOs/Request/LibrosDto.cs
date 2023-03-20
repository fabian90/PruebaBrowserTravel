using System;
using System.Collections.Generic;

namespace Biblioteca.Core.DTOs.Request;

public partial class LibrosDto
{
    public long Isbn { get; set; }

    public int? EditorialesId { get; set; }

    public string? Titulo { get; set; }

    public string? Sinopsis { get; set; }

    public string? NPaginas { get; set; }

    public virtual ICollection<AutoresHasLibroDto> AutoresHasLibros { get; } = new List<AutoresHasLibroDto>();

    public virtual EditorialesDto? Editoriales { get; set; }
}
