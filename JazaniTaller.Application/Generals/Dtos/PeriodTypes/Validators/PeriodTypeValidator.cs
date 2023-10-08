using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;


namespace JazaniTaller.Application.Generals.Dtos.PeriodTypes.Validators
{
    public class PeriodTypeValidator : AbstractValidator<PeriodTypeSaveDto>
    {
        public PeriodTypeValidator() {
            RuleFor(x => x.Name)
                .NotNull()
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.")
            .MaximumLength(20)
            .WithMessage("El nombre debe tener como máximo 20 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(50)
                .WithMessage("La descripción debe tener como máximo 50 caracteres.");

            RuleFor(x => x.Time)
                .NotNull ()
                .NotEmpty()
                .WithMessage("El tiempo es obligatorio.");

        }
    }
}
