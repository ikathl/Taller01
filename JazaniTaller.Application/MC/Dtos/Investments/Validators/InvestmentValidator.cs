using FluentValidation;

namespace JazaniTaller.Application.MC.Dtos.Investments.Validators
{
    public class InvestmentValidator : AbstractValidator<InvestmentSaveDto>
    {
        public InvestmentValidator()
        {
            RuleFor(x => x.AmountInvested)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.MiningConcessionId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.InvestmentTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CurrencyTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.HolderId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DeclaredTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Description)
                .MaximumLength(200);

            RuleFor(x => x.MonthName)
                .MaximumLength(25);

            RuleFor(x => x.AccreditationCode)
                .MaximumLength(50);

            RuleFor(x => x.AccountantCode)
                .MaximumLength(50);

            RuleFor(x => x.MetricTons)
                .MaximumLength(50);

            RuleFor(x => x.Year)
                .InclusiveBetween(1900, DateTime.Now.Year)
                .When(x => x.Year.HasValue);

        }

    }
}
