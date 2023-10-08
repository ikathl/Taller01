using FluentValidation;

namespace JazaniTaller.Application.Generals.Dtos.MesureUnits.Validators
{
    public class MeasureUnitValidator : AbstractValidator<MeasureUnitSaveDto>
    {
        public MeasureUnitValidator() {
            RuleFor(x => x.Name)
                .NotNull()
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.")
            .MaximumLength(30)
            .WithMessage("El nombre debe tener como máximo 30 caracteres.")
            .Matches("^[a-zA-Z0-9 ]+$")
            .WithMessage("El nombre solo debe contener letras, números y espacios.");

            RuleFor(x => x.Symbol)
                .NotNull()
                .NotEmpty()
                .WithMessage("El símbolo es obligatorio.")
                .MaximumLength(5)
                .WithMessage("El símbolo debe tener como máximo 5 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(2147483647) // Longitud máxima para varchar(max)
                .WithMessage("La descripción debe tener como máximo 2147483647 caracteres.");

            RuleFor(x => x.FormulaConversion)
                .MaximumLength(100)
                .WithMessage("La fórmula de conversión debe tener como máximo 100 caracteres.");

        }
        
    }
}
