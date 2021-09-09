using FluentValidation;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;

namespace LinkManager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>, IUserValidator
    {
        public UserValidator(
            IUserRepository userRepository,
            IPasswordValidator passwordValidator,
            IEmailValidator emailValidator
        )
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(150)
                .WithName("Nome");

            RuleFor(r => r.Email)
                .SetValidator(emailValidator);

            RuleFor(r => r)
                .MustAsync(async (user, cancellation) =>
                {
                    var entity = await userRepository.GetByEmailAsync(user.Email);
                    if (entity != null)
                    {
                        return user.Id == entity.Id;
                    }

                    return true;
                })
                .WithMessage("O email informado já está sendo usado.");

            RuleFor(r => r.Password)
                .SetValidator(passwordValidator);
        }
    }
}