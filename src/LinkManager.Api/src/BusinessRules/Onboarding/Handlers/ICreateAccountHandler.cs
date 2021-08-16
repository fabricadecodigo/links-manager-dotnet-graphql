using LinkManager.Api.src.BusinessRules.Onboarding.Requests;
using LinkManager.Api.src.BusinessRules.Onboarding.Responses;

namespace LinkManager.Api.src.BusinessRules.Onboarding.Handlers
{
    public interface ICreateAccountHandler : IBusinessRuleHandler<CreateAccountRequest, CreateAccountResponse, bool>
    {
        
    }
}