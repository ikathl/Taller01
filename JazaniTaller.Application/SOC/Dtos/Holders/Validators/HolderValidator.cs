using FluentValidation;

namespace JazaniTaller.Application.SOC.Dtos.Holders.Validators
{
    public class HolderValidator : AbstractValidator<HolderSaveDto>
    {
        public HolderValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre es obligatorio.")
                .MaximumLength(100)
                .WithMessage("El nombre debe tener como máximo 100 caracteres.");


            RuleFor(x => x.MaidenName)
                .NotEmpty()
                .WithMessage("El apellido de soltera es obligatorio.")
                .MaximumLength(100)
                .WithMessage("El apellido de soltera debe tener como máximo 100 caracteres.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty()
                .WithMessage("El número de documento es obligatorio.")
                .MaximumLength(15)
                .WithMessage("El número de documento debe tener como máximo 15 caracteres.");

           

            RuleFor(x => x.Mobile)
                .MaximumLength(10)
                .WithMessage("El número de teléfono móvil debe tener como máximo 10 caracteres.");

        }
    }
}
