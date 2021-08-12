using FluentValidation;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Domain.src.Entities;

namespace LinkManager.Api.src.BusinessRules.Users.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
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