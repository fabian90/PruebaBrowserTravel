using Biblioteca.Core.DTOs.Request;
using FluentValidation;

namespace Biblioteca.Validators
{
    public class LibrosValidator: AbstractValidator<LibrosDto>
    {
        public LibrosValidator()
        {
            Include(new LibrosIsSpecified());
        }
    }
    public class LibrosIsSpecified : AbstractValidator<LibrosDto>
    {
    }
}
