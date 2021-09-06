using FluentValidation;
using LinkManager.BusinessRules.Onboarding.Requests;

namespace LinkManager.BusinessRules.Onboarding.Validators
{
    public interface ICreateUserValidator : IValidator<CreateAccountRequestUser>
    {

    }
}