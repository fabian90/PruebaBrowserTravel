using System;
using System.Collections.Generic;

namespace Biblioteca.Core.DTOs.Request;

public partial class AutoresHasLibroDto
{
    public int Id { get; set; }

    public int AutoresId { get; set; }

    public long LibrosIsbn { get; set; }

    public virtual AutoresDto Autores { get; set; } = null!;

    public virtual LibrosDto LibrosIsbnNavigation { get; set; } = null!;
}
