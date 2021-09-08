using FluentValidation;
using LinkManager.Domain.Entities;

namespace LinkManager.Domain.Validators
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPassword>, IForgotPasswordValidator
    {
        public ForgotPasswordValidator()
        {
            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithName("E-mail");
        }
    }
}