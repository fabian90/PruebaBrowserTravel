using Biblioteca.Core.DTOs.Request;
using FluentValidation;

namespace Biblioteca.Validators
{
    public class EditorialesValidator : AbstractValidator<EditorialesDto>
    {
        public EditorialesValidator()
        {
            Include(new EditorialesIsSpecified());
        }
    }
    public class EditorialesIsSpecified : AbstractValidator<EditorialesDto>
    {
    }
}
