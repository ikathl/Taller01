using FluentValidation;


namespace JazaniTaller.Application.MC.Dtos.InvestmentTypes.Validators
{
    public class InvestmentTypeValidator : AbstractValidator<InvestmentTypeSaveDto>
    {
        public InvestmentTypeValidator()
        {
            RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.")
            .MaximumLength(50)
            .WithMessage("El nombre debe tener como máximo 50 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("La descripción debe tener como máximo 200 caracteres.");
        }
    }
}
