using Biblioteca.Core.DTOs.Request;
using FluentValidation;

namespace Biblioteca.Validators
{
    public class AutoresHasLibroValidator: AbstractValidator<AutoresHasLibroDto>
    {
        public AutoresHasLibroValidator()
        {
            Include(new AutoresHasLibroIsSpecified());
        }
    }
    public class AutoresHasLibroIsSpecified : AbstractValidator<AutoresHasLibroDto>
    {
    }
}
