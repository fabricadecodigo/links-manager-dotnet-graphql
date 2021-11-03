using LinkManager.BusinessRules.Account.Requests;
using LinkManager.BusinessRules.Account.Responses;

namespace LinkManager.BusinessRules.Account.Handlers
{
    public interface IForgotPassowordHandler : 
        IBusinessRuleHandler<ForgotPasswordRequest, ForgotPasswordResponse, bool>
    {
        
    }
}