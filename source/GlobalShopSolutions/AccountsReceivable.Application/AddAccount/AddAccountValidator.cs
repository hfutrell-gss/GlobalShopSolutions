using FluentValidation;

namespace AccountsReceivable.Application.AddAccount;

public sealed class AddAccountValidator : AbstractValidator<AddAccountCommand>
{
    public AddAccountValidator()
    {
        RuleFor(a => a.Name)
            .Length(3, 24)
            ;
    }
}