using Application.UseCases.Commands;
using FluentValidation;

namespace Application.UseCases.Commands.Validators
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.AccountNumber)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.InitialDeposit)
                .GreaterThan(0)
                .WithMessage("O depósito inicial deve ser maior que 0");
        }
    }
}
