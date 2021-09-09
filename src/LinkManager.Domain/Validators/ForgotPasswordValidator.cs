using FluentValidation;
using LinkManager.Domain.Entities;

namespace LinkManager.Domain.Validators
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPassword>, IForgotPasswordValidator
    {
        public ForgotPasswordValidator(
            IEmailValidator emailValidator
        )
        {
            RuleFor(r => r.Email)
                .SetValidator(emailValidator);
        }
    }
}