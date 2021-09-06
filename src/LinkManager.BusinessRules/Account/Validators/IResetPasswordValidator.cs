using FluentValidation;
using LinkManager.BusinessRules.Account.Requests;

namespace LinkManager.BusinessRules.Account.Validators
{
    public interface IResetPasswordValidator : IValidator<ResetPasswordRequest>
    {

    }
}