using FluentValidation;

namespace LinkManager.Domain.Validators
{
    public class EmailValidator : AbstractValidator<string>, IEmailValidator
    {
        public EmailValidator()
        {
            RuleFor(email => email)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200)
                .EmailAddress()
                .WithName("E-mail");
        }
    }
}