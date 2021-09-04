using LinkManager.BusinessRules.Onboarding.Requests;
using LinkManager.BusinessRules.Onboarding.Responses;

namespace LinkManager.BusinessRules.Onboarding.Handlers
{
    public interface ICreateAccountHandler : IBusinessRuleHandler<CreateAccountRequest, CreateAccountResponse, bool>
    {
        
    }
}