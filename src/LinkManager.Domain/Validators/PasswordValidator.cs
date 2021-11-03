using FluentValidation;

namespace LinkManager.Domain.Validators
{
    public class PasswordValidator : AbstractValidator<string>, IPasswordValidator
    {
        public PasswordValidator()
        {
            RuleFor(password => password)
                .NotEmpty()
                .MinimumLength(2)
                .WithName("Senha");
        }
    }
}