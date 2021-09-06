using FluentValidation;
using LinkManager.BusinessRules.Onboarding.Requests;
using LinkManager.Domain.Repositories;

namespace LinkManager.BusinessRules.Onboarding.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateAccountRequestUser>, ICreateUserValidator
    {
        public CreateUserValidator(
            IUserRepository userRepository
        )
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
                .EmailAddress()
                .WithName("E-mail");

            RuleFor(r => r.Email)
                .MustAsync(async (email, cancellation) =>
                {
                    var existsUsers = await userRepository.GetByEmailAsync(email);
                    return existsUsers == null;
                })
                .WithMessage("O email informado já está sendo usado.");

            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(2)
                .WithName("Senha");
        }
    }
}