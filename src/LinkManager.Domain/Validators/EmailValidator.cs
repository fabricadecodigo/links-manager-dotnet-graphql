using FluentValidation;

namespace LinkManager.Domain.Validators
{
    public class EmailValidator : AbstractValidator<string>, IEmailValidator
    {
        public EmailValidator()
        {
            RuleFor(r => r)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200)
                .EmailAddress()
                .WithName("E-mail");
        }
    }
}