namespace LinkManager.BusinessRules.Account.Validators
{
    using FluentValidation;
    using LinkManager.BusinessRules.Account.Requests;

    public class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>, IResetPasswordValidator
    {
        public ResetPasswordValidator()
        {
            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(2)
                .WithName("Senha");
        }
    }
}