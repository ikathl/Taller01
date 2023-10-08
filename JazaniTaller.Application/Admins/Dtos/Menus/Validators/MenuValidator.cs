using FluentValidation;

namespace JazaniTaller.Application.Admins.Dtos.Menus.Validators
{
    public class MenuValidator : AbstractValidator<MenuSaveDto>
    {
        public MenuValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Visible)
                .NotNull()
                .NotEmpty();
        }
    }
}
