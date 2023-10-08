using FluentValidation;

namespace JazaniTaller.Application.MC.Dtos.InvestmentsConcepts.Validators
{
    public class InvestmentConceptValidator : AbstractValidator<InvestmentConceptSaveDto>
    {
        public InvestmentConceptValidator()
        {
            RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
        }
    }
}
