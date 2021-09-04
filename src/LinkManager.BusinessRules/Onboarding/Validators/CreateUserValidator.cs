using FluentValidation;
using LinkManager.BusinessRules.Onboarding.Requests;

namespace LinkManager.BusinessRules.Onboarding.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateAccountRequestUser>
    {
        public CreateUserValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(150)
                .WithName("Nome");

            RuleFor(r => r.Email)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200)
                .WithName("E-mail");

            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(2)
                .WithName("Senha");
        }
    }
}