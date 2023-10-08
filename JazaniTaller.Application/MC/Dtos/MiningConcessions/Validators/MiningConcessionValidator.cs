using FluentValidation;

namespace JazaniTaller.Application.MC.Dtos.MiningConcessions.Validators
{
    public class MiningConcessionValidator:AbstractValidator<MiningConcessionSaveDto>
    {
        public MiningConcessionValidator()
        {
            RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.MineralTypeId)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.TypeId)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.SituationId)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.MiningUnitId)
            .NotNull()
            .NotEmpty();
            
            RuleFor(x => x.ConditionId)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.StateManagementId)
            .NotNull()
            .NotEmpty();

        }
    }
}
