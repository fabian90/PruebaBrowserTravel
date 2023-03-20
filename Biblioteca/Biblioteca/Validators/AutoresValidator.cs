using Biblioteca.Core.DTOs.Request;
using FluentValidation;

namespace Biblioteca.Validators
{
    public class AutoresValidator:AbstractValidator<AutoresDto>
    {
        public AutoresValidator()
        {
            Include(new AutoresIsSpecified());
        }
    }
    public class AutoresIsSpecified : AbstractValidator<AutoresDto>
    {
    }
}
